using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class ReviewCreatedFeedEventConverter : IReviewCreatedFeedEventConverter
    {
        private readonly IFeedEventConverter feedEventConverter;

        public ReviewCreatedFeedEventConverter(IFeedEventConverter feedEventConverter)
        {
            this.feedEventConverter = feedEventConverter;
        }

        public ReviewCreatedFeedEvent Convert(ReviewCreatedFeedEventBean reviewCreatedFeedEventBean)
        {
            var reviewCreatedFeedEvent = feedEventConverter.Convert<ReviewCreatedFeedEvent>(reviewCreatedFeedEventBean.Base);
            reviewCreatedFeedEvent.Revisions = reviewCreatedFeedEventBean.Revisions ?? new string[0];

            return reviewCreatedFeedEvent;
        }
    }
}