namespace DomainLogic

module Election = 
    open InfrastructureTypes
    open PositiveNumber
    open NotNegativeNumber
    open Tracking
    
    type RelevantReviewers = seq<Reviewer>
    
    and Reviewer = 
        { Name : Name
          SentToAuthorReviewsCount : NotNegativeNumber
          TotalSentReviewsCount : NotNegativeNumber
          TotalReceivedReviewsCount : NotNegativeNumber }
    
    and Author = Developer
    
    and Mate = Developer
    
    and Developer = 
        { Reviewers : seq<Reviewer> }
    
    and OrderByRating = seq<Reviewer> -> RelevantReviewers
    
    and ChooseBySingle = Author -> RelevantReviewers
    
    and ChooseByPair = Author * Mate -> RelevantReviewers
    
    let private calculateRating (reviewer : Reviewer) : PositiveNumber = 
        let sentToAuthorReviewsCount = reviewer.SentToAuthorReviewsCount |> NotNegativeNumber.Increment
        let totalSentReviewsCount = reviewer.TotalSentReviewsCount |> NotNegativeNumber.Increment
        let totalReceivedReviewsCount = reviewer.TotalReceivedReviewsCount |> NotNegativeNumber.Increment
        sentToAuthorReviewsCount * totalSentReviewsCount / totalReceivedReviewsCount
    
    let private orderByRating : OrderByRating = 
        Seq.sortBy (calculateRating >> PositiveNumber.value)

    let chooseBySingle : ChooseBySingle = 
        fun author -> author.Reviewers |> orderByRating

    let chooseByPair : ChooseByPair = 
        fun (author, mate) -> Seq.append author.Reviewers mate.Reviewers |> orderByRating

    let private selectRelevantReviews (user : User) (reviews : seq<Review>) : seq<Review> = 
        reviews 
        |> Seq.filter (fun r -> 
            r.Authors
            |> (List.contains user)
            || 
            r.Reviewers 
            |> (List.contains user)
        )
    
    let private convertLink (author : User) (reviewerLink : ReviewerLink) : Reviewer = 
        let getLength = Seq.length >> NotNegativeNumber
        {
            Name = reviewerLink.User.Name
            SentToAuthorReviewsCount = 
                reviewerLink.Outgoing
                |> Seq.filter (fun u -> u = author)
                |> getLength
            TotalSentReviewsCount = reviewerLink.Outgoing |> getLength
            TotalReceivedReviewsCount = reviewerLink.Incoming |> getLength 
        }
    
    let buildDeveloper (user : User, reviews : seq<Review>) : Developer = 
        let convertLinkWithUserContext = convertLink user
        let reviewers = 
            selectRelevantReviews user reviews
            |> buildReviewerLinks
            |> Seq.map convertLinkWithUserContext
        { Reviewers = reviewers }
