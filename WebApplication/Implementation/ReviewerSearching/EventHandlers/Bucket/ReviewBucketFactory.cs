using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models.Converters;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Bucket
{
    public class ReviewBucketFactory : IReviewBucketFactory
    {
        private readonly IReviewConverter reviewConverter;

        public ReviewBucketFactory(IReviewConverter reviewConverter)
        {
            this.reviewConverter = reviewConverter;
        }

        public IReviewBucket Create(ReviewModel[] reviewModels)
        {
            return new ReviewBucket(reviewModels, reviewConverter);
        }
    }
}