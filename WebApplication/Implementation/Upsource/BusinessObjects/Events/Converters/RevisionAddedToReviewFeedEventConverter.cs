using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class RevisionAddedToReviewFeedEventConverter : IRevisionAddedToReviewFeedEventConverter
    {
        private readonly IFeedEventConverter feedEventConverter;

        public RevisionAddedToReviewFeedEventConverter(IFeedEventConverter feedEventConverter)
        {
            this.feedEventConverter = feedEventConverter;
        }

        public RevisionAddedToReviewFeedEvent Convert(RevisionAddedToReviewFeedEventBean revisionAddedToReviewFeedEventBean)
        {
            var revisionAddedToReviewFeedEvent = feedEventConverter.Convert<RevisionAddedToReviewFeedEvent>(revisionAddedToReviewFeedEventBean.Base);
            revisionAddedToReviewFeedEvent.RevisionIds = revisionAddedToReviewFeedEventBean.RevisionIds ?? new string[0];

            return revisionAddedToReviewFeedEvent;
        }
    }
}