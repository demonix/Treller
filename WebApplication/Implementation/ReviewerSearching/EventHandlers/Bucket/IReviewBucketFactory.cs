using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Bucket
{
    public interface IReviewBucketFactory
    {
        IReviewBucket Create(ReviewModel[] reviewModels);
    }
}