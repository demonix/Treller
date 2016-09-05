namespace DomainLogic

module Election =

    open InfrastructureTypes

    type RelevantReviewers = seq<Reviewer>

    and Reviewer = {
        User: User
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
    and CalculateRating = 
        Reviewer -> NotNegativeNumber

    and ChooseBySingle = 
        Author -> RelevantReviewers
    and ChooseByPair =
        Author * Mate -> RelevantReviewers

    let private calculateRating : CalculateRating =
        fun (reviewer) ->
            (reviewer.SentToAuthorReviewsCount + 1) * (reviewer.TotalSentReviewsCount + 1) / (reviewer.TotalReceivedReviewsCount + 1)

    let private orderByRating : OrderByRating =
        fun (reviewers) ->
            Seq.sortBy calculateRating reviewers

    let chooseBySingle : ChooseBySingle =
        fun (author) ->
            author.Reviewers 
            |> orderByRating

    let chooseByPair  : ChooseByPair =
        fun (author, mate) ->
            Seq.append author.Reviewers mate.Reviewers 
            |> orderByRating
            