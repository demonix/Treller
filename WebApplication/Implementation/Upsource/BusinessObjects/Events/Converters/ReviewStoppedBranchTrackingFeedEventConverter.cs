using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class ReviewStoppedBranchTrackingFeedEventConverter : IReviewStoppedBranchTrackingFeedEventConverter
    {
        private readonly IFeedEventConverter feedEventConverter;

        public ReviewStoppedBranchTrackingFeedEventConverter(IFeedEventConverter feedEventConverter)
        {
            this.feedEventConverter = feedEventConverter;
        }

        public ReviewStoppedBranchTrackingFeedEvent Convert(ReviewStoppedBranchTrackingFeedEventBean reviewStoppedBranchTrackingFeedEventBean)
        {
            var reviewStoppedBranchTrackingFeedEvent = feedEventConverter.Convert<ReviewStoppedBranchTrackingFeedEvent>(reviewStoppedBranchTrackingFeedEventBean.Base);
            reviewStoppedBranchTrackingFeedEvent.Branch = reviewStoppedBranchTrackingFeedEventBean.Branch;

            return reviewStoppedBranchTrackingFeedEvent;
        }
    }
}