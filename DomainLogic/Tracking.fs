namespace DomainLogic

module Tracking = 
    open CommonTypes
    
    type Timestamp = 
        | Timestamp of int64
    
    and User = 
        { Name : Name
          Id : ExternalId }
    
    and Event = 
        { ReviewId : ExternalId
          Timestamp : Timestamp
          Data : EventData }
    
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
    
    and NewParticipantInReview = 
        { Participant : User
          Role : ParticipantRole }
    
    and RemovedParticipantFromReview = 
        { Participant : User
          RoleHadBeforeBeingRemoved : ParticipantRole }
    
    and ReviewStateChanged = 
        { NewState : ReviewState }
    
    and ParticipantRole = 
        | Author
        | Reviewer
        | Watcher
    
    and ReviewState = 
        | Open
        | Closed
    
    and Review = 
        { Id : ExternalId
          Timestamp : Timestamp
          Authors : list<User>
          Reviewers : list<User>
          State : ReviewState }
    
    and ReviewerLink = 
        { User : User
          Outgoing : seq<User>
          Incoming : seq<User> }
    
    and ApplyEvent = Event * seq<Review> -> seq<Result<Review, string>>
    
    and BuildReviewerLinks = seq<Review> -> seq<ReviewerLink>
    
    let private roll (event : Event, review : Review) : Review = 
        let notUser (first : User) (second : User) = second.Id <> first.Id
        
        let origin = (review.Authors, review.Reviewers, review.State)
        let (authors, reviewers, state) = 
            match event.Data with
            | NewParticipantInReview data -> 
                match data.Role with
                | Author ->
                    (data.Participant :: review.Authors, review.Reviewers, review.State)
                | Reviewer ->
                    (review.Authors, data.Participant :: review.Reviewers, review.State)
                | _ ->
                    origin
            | RemovedParticipantFromReview data -> 
                let notParticipant = notUser data.Participant
                (
                    review.Authors |> List.filter notParticipant, 
                    review.Authors |> List.filter notParticipant, 
                    review.State
                )
            | ReviewStateChanged data -> 
                (review.Authors, review.Reviewers, data.NewState)
            | _ -> origin

        { 
            Id = review.Id
            Timestamp = event.Timestamp
            Authors = authors
            Reviewers = reviewers
            State = state
        }
    
    let private safeRoll (event : Event) (review : Review) = 
        match event with
        | e when e.Timestamp < review.Timestamp -> sprintf "Event timestamp less than review timestamp. Event %A | Review %A" e review |> Error
        | e when e.ReviewId = review.Id -> roll (event, review) |> Success
        | _ -> review |> Success
    
    let private createReview (id : ExternalId, timestamp : Timestamp) : Review = 
        { 
            Id = id
            Timestamp = timestamp
            Authors = list.Empty
            Reviewers = list.Empty
            State = Open 
        }
    
    let private applyEventToReviews (event : Event, reviews : list<Review>) : list<Result<Review, string>> = 
        match event.Data with
        | ReviewCreated -> createReview (event.ReviewId, event.Timestamp) :: reviews |> List.map Success
        | ReviewRemoved -> 
            reviews
            |> List.filter (fun review -> review.Id <> event.ReviewId)
            |> List.map Success
        | _ -> reviews |> List.map (safeRoll event)
    
    let applyEvent : ApplyEvent = 
        fun (event, reviews) -> applyEventToReviews (event, reviews |> Seq.toList) |> Seq.ofList
    
    let private buildByAuthor (reviewers : list<User>) (author : User) : ReviewerLink = 
        { User = author
          Outgoing = list.Empty
          Incoming = reviewers }
    
    let private buildByReviewer (authors : list<User>) (reviewer : User) : ReviewerLink = 
        { User = reviewer
          Outgoing = authors
          Incoming = list.Empty }
    
    let private mergeUserLinks (user : User, reviewerLinks : seq<ReviewerLink>) : ReviewerLink = 
        let outgoing = 
            reviewerLinks
            |> Seq.map (fun r -> r.Outgoing)
            |> Seq.concat
        
        let incoming = 
            reviewerLinks
            |> Seq.map (fun r -> r.Incoming)
            |> Seq.concat
        
        { User = user
          Outgoing = outgoing
          Incoming = incoming }
    
    let private mergeLinks (reviewerLinks : seq<ReviewerLink>) : seq<ReviewerLink> = 
        reviewerLinks
        |> Seq.groupBy (fun r -> r.User)
        |> Seq.map mergeUserLinks
    
    let private buildLinks (review : Review) : seq<ReviewerLink> = 
        let authorLinks = review.Authors |> List.map (buildByAuthor review.Reviewers)
        let reviewerLinks = review.Reviewers |> List.map (buildByReviewer review.Authors)
        List.append authorLinks reviewerLinks
        |> Seq.ofList
        |> mergeLinks
    
    let buildReviewerLinks : BuildReviewerLinks = Seq.map buildLinks >> Seq.concat
