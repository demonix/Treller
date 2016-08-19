using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class ReviewStateChangedFeedEventConverter : IReviewStateChangedFeedEventConverter
    {
        private readonly IFeedEventConverter feedEventConverter;

        public ReviewStateChangedFeedEventConverter(IFeedEventConverter feedEventConverter)
        {
            this.feedEventConverter = feedEventConverter;
        }

        public ReviewStateChangedFeedEvent Convert(ReviewStateChangedFeedEventBean reviewStateChangedFeedEventBean)
        {
            var reviewStateChangedFeedEvent = feedEventConverter.Convert<ReviewStateChangedFeedEvent>(reviewStateChangedFeedEventBean.Base);
            reviewStateChangedFeedEvent.NewState = reviewStateChangedFeedEventBean.NewState;
            reviewStateChangedFeedEvent.OldState = reviewStateChangedFeedEventBean.OldState;

            return reviewStateChangedFeedEvent;
        }
    }
}