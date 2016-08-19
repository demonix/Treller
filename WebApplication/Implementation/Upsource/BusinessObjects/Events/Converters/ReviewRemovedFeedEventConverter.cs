using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class ReviewRemovedFeedEventConverter : IReviewRemovedFeedEventConverter
    {
        private readonly IFeedEventConverter feedEventConverter;

        public ReviewRemovedFeedEventConverter(IFeedEventConverter feedEventConverter)
        {
            this.feedEventConverter = feedEventConverter;
        }

        public ReviewRemovedFeedEvent Convert(ReviewRemovedFeedEventBean reviewRemovedFeedEventBean)
        {
            var reviewRemovedFeedEvent = feedEventConverter.Convert<ReviewRemovedFeedEvent>(reviewRemovedFeedEventBean.Base);
            reviewRemovedFeedEvent.ReviewId = reviewRemovedFeedEventBean.ReviewId;

            return reviewRemovedFeedEvent;
        }
    }
}