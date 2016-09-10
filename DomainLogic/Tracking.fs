namespace DomainLogic

module Tracking =
    
    open InfrastructureTypes

    type Timestamp = Timestamp of double
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

    and ApplyEvent = Event * seq<Review> -> seq<Review option>
    and SelectReviewers = seq<Review> -> seq<ReviewerLink>
    

    let private roll(event: Event, review: Review) : Review = 
        let notUser (first: User) (second: User) = second.Id <> first.Id
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

    let private safeRoll (event: Event) (review: Review) =
        match event with
            | e when e.Timestamp < review.Timestamp -> Option.None
            | e when e.ReviewId = review.Id -> roll(event, review) |> Option.Some
            | _ -> review |> Option.Some

               
               
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
        fun (event, reviews) ->
            applyEventToReviews(event, reviews |> Seq.toList) |> Seq.ofList

    let private buildByAuthor(reviewers: list<User>) (author: User) : ReviewerLink =
        {
            User = author
            Outgoing = list.Empty
            Incoming = reviewers
        }

    let private buildByReviewer(authors: list<User>) (reviewer: User) : ReviewerLink =
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
        |> Seq.map mergeUserLinks
        
    let private selectLinks(reviewData: ReviewData) : seq<ReviewerLink> =
        let authorLinks = 
            reviewData.Authors 
            |> List.map (buildByAuthor reviewData.Reviewers)
                
        let reviewerLinks = 
            reviewData.Reviewers
            |> List.map (buildByReviewer reviewData.Authors)
                
        List.append authorLinks reviewerLinks 
        |> Seq.ofList 
        |> mergeLinks


    let selectReviewers : SelectReviewers = 
        Seq.map ((fun (r) -> r.Data) >> selectLinks) 
        >> Seq.concat
            