namespace DomainLogic.Tests.Tracking

open NUnit.Framework
open FsUnit

open DomainLogic.CommonTypes
open DomainLogic.Tracking

[<TestFixture>] 
type ``Review links actualization`` ()=
   let reviewCreatedEvent = 
        {
            ReviewId = ExternalId "some id"
            Timestamp = Timestamp 123L
            Data = ReviewCreated
        }
   let firstReview =
        {
            Id = reviewCreatedEvent.ReviewId
            Timestamp = reviewCreatedEvent.Timestamp
            Authors = list.Empty
            Reviewers = list.Empty
            State = Open 
        }
   [<Test>] member test.
    ``On review created event must create new review in list`` ()=     
        applyEvent (reviewCreatedEvent, Seq.empty) |> should contain (firstReview |> Result<Review, string>.Success)
