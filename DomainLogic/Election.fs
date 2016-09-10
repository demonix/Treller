namespace DomainLogic

module Election =

    open InfrastructureTypes
    open PositiveNumber
    open NotNegativeNumber
    open Tracking

    type RelevantReviewers = seq<Reviewer>

    and Reviewer = {
        Name: Name
        SentToAuthorReviewsCount: NotNegativeNumber
        TotalSentReviewsCount: NotNegativeNumber
        TotalReceivedReviewsCount: NotNegativeNumber
    }

    and Author = Developer
    and Mate = Developer
    and Developer = {
        Reviewers: seq<Reviewer>
    }

    and OrderByRating =
        seq<Reviewer> -> RelevantReviewers

    and ChooseBySingle = 
        Author -> RelevantReviewers
    and ChooseByPair =
        Author * Mate -> RelevantReviewers

    let private calculateRating (reviewer: Reviewer) : PositiveNumber =
        let sentToAuthorReviewsCount = reviewer.SentToAuthorReviewsCount |> NotNegativeNumber.Increment
        let totalSentReviewsCount = reviewer.TotalSentReviewsCount  |> NotNegativeNumber.Increment
        let totalReceivedReviewsCount = reviewer.TotalReceivedReviewsCount |> NotNegativeNumber.Increment
        sentToAuthorReviewsCount * totalSentReviewsCount / totalReceivedReviewsCount

    let private orderByRating : OrderByRating =
        fun (reviewers) ->
            Seq.sortBy (calculateRating >> PositiveNumber.value) reviewers

    let chooseBySingle : ChooseBySingle =
        fun (author) ->
            author.Reviewers 
            |> orderByRating

    let chooseByPair  : ChooseByPair =
        fun (author, mate) ->
            Seq.append author.Reviewers mate.Reviewers 
            |> orderByRating

    let private selectRelevantReviews(user: User, reviews: seq<Review>) : seq<Review> =
        reviews
        |> Seq.filter (fun r -> 
            r.Data.Authors 
            |> (List.contains user) 
            || 
            r.Data.Reviewers 
            |> (List.contains user))

//    let private convertLink(reviewerLink: ReviewerLink, author: User) : Reviewer =
//        {
//            Name = reviewerLink.User.Name
//            SentToAuthorReviewsCount = reviewerLink.Outgoing |> Seq.filter (fun u -> u = author) |> Seq.countBy (fun x -> x)
//            TotalSentReviewsCount = reviewerLink.Outgoing |> Seq.countBy (fun x -> x)
//            TotalReceivedReviewsCount = reviewerLink.Incoming |> Seq.countBy (fun x -> x)
//        }
//
//    let private buildDeveloper(user: User, reviews: seq<Review>) : Developer =
//        let reviewers =
//            selectRelevantReviews user reviews
//            |> selectReviewers
//            |> Seq.map convertLink
//        { Reviewers = reviewers }
            