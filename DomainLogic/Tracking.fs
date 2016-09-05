namespace DomainLogic

module Tracking =
    
    open InfrastructureTypes

    type TrackingMachine = TrackingInput -> DeveloperRelations

    and TrackingInput = {
        Event: Event
        DeveloperRelations: DeveloperRelations
    }
    and Timestamp = Timestamp of double
    and User = {
        Name: Name
        Id: ExternalId
    }
    and Event = {
        Id: ExternalId
        ReviewId: ExternalId
        Timestamp: Timestamp
        Data: EventData
    }
    and EventData = 
        | Discussion
        | NewParticipantInReview of NewParticipantInReview
        | NewRevision
        | ParticipantStateChanged
        | PullRequestMerged
        | RemovedParticipantFromReview of RemovedParticipantFromReview
        | ReviewCreated
        | ReviewRemoved
        | ReviewStateChanged of ReviewStateChanged
        | ReviewStoppedBranchTracking
        | RevisionAddedToReview
        | RevisionRemovedFromReview
    and NewParticipantInReview = {
        Participant: User
        Role: ParticipantRole
    }
    and RemovedParticipantFromReview = {
        Participant: User
        RoleHadBeforeBeingRemoved: ParticipantRole
    }
    and ReviewStateChanged = {
        NewState: ReviewState
    }
    and ParticipantRole = 
        | Author
        | Reviewer
        | Watcher
    and ReviewState = 
        | Open
        | Closed

    and DeveloperRelations = {
        Reviews: seq<Review>
    }
    and Review = {
        Id: ExternalId
        Timestamp: Timestamp
        Data: ReviewData
    }
    and ReviewData = {
        Authors: list<User>
        Reviewers: list<User>
        State: ReviewState
    }
    and ReviewerLink = {
        User: User
        Outgoing: seq<User>
        Incoming: seq<User>
    }

    and ApplyEvent = Event * DeveloperRelations -> seq<Review option>
    and SelectReviewers = DeveloperRelations -> seq<ReviewerLink>
    

    let private roll(event: Event, review: Review) : Review = 
        let notUser (first: User) = 
            fun (second: User) ->
                second.Id <> first.Id
                
        let reviewData = review.Data

        let updatedData = 
            match event.Data with
            | NewParticipantInReview data ->
                match data.Role with
                | Author ->
                    {
                        Authors = data.Participant :: reviewData.Authors
                        Reviewers = reviewData.Reviewers
                        State = reviewData.State
                    }
                | Reviewer ->
                    {
                        Authors = reviewData.Authors
                        Reviewers = data.Participant :: reviewData.Reviewers
                        State = reviewData.State
                    }
                | _ -> reviewData
            | RemovedParticipantFromReview data ->
                let notParticipant = notUser data.Participant
                {
                    Authors = reviewData.Authors |> List.filter notParticipant
                    Reviewers = reviewData.Reviewers |> List.filter notParticipant
                    State = reviewData.State
                }
            | ReviewStateChanged data ->
                {
                    Authors = reviewData.Authors
                    Reviewers = reviewData.Reviewers
                    State = data.NewState
                }
            |_ -> review.Data

        {
            Id = review.Id
            Timestamp = event.Timestamp
            Data = updatedData
        }

    let private safeRoll (event: Event) =
        let ``with`` review =
            match event with
                | e when e.Timestamp < review.Timestamp -> Option.None
                | e when e.ReviewId = review.Id -> roll(event, review) |> Option.Some
                | _ -> review |> Option.Some
        ``with``

               
               
    let private createReview (id: ExternalId, timestamp: Timestamp) : Review =
        {
            Id = id
            Timestamp = timestamp
            Data = 
            {
                Authors = list.Empty
                Reviewers = list.Empty
                State = Open
            }
        }

    let private applyEventToReviews(event: Event, reviews: list<Review>) : list<Review option> =
        match event.Data with
            | ReviewCreated -> 
                createReview(event.ReviewId, event.Timestamp) :: reviews 
                |> List.map Option.Some
            | ReviewRemoved -> 
                reviews 
                |> List.filter (fun (review) -> review.Id <> event.ReviewId) 
                |> List.map Option.Some
            | _ ->
                reviews
                |> List.map (safeRoll event)
        

    let applyEvent : ApplyEvent =
        fun (event, developerRelations) ->
            applyEventToReviews(event, developerRelations.Reviews |> Seq.toList) |> Seq.ofList

    let private buildByAuthor(author: User, reviewers: list<User>) : ReviewerLink =
        {
            User = author
            Outgoing = list.Empty
            Incoming = reviewers
        }

    let private buildByReviewer(reviewer: User, authors: list<User>) : ReviewerLink =
        {
            User = reviewer
            Outgoing = authors
            Incoming = list.Empty
        }

    let private mergeUserLinks(user: User, reviewerLinks: seq<ReviewerLink>) : ReviewerLink =
        let outgoing = 
            reviewerLinks
            |> Seq.map (fun r -> r.Outgoing)
            |> Seq.concat

        let incoming = 
            reviewerLinks
            |> Seq.map (fun r -> r.Incoming)
            |> Seq.concat
        {
            User = user
            Outgoing = outgoing
            Incoming = incoming
        }

    let private mergeLinks(reviewerLinks: seq<ReviewerLink>) : seq<ReviewerLink> =
        reviewerLinks
        |> Seq.groupBy (fun r -> r.User)
        |> Seq.map (fun (key, collection) -> mergeUserLinks (key, collection))
        
    let private selectLinks(reviewData: ReviewData) : seq<ReviewerLink> =
        let authorLinks = 
            reviewData.Authors 
            |> List.map (fun (u) -> buildByAuthor(u, reviewData.Reviewers))
                
        let reviewerLinks = 
            reviewData.Reviewers
            |> List.map (fun (u) -> buildByReviewer(u, reviewData.Authors))
                
        (authorLinks |> List.append <| reviewerLinks) |> Seq.ofList |> mergeLinks


    let selectReviewers : SelectReviewers = 
        fun (developerRelations) -> 
            developerRelations.Reviews 
            |> Seq.map ((fun (r) -> r.Data) >> selectLinks)
            |> Seq.concat
            