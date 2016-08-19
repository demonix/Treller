using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class RevisionRemovedFromReviewFeedEventConverter : IRevisionRemovedFromReviewFeedEventConverter
    {
        private readonly IFeedEventConverter feedEventConverter;

        public RevisionRemovedFromReviewFeedEventConverter(IFeedEventConverter feedEventConverter)
        {
            this.feedEventConverter = feedEventConverter;
        }

        public RevisionRemovedFromReviewFeedEvent Convert(RevisionRemovedFromReviewFeedEventBean revisionRemovedFromReviewFeedEventBean)
        {
            var revisionRemovedFromReviewFeedEvent = feedEventConverter.Convert<RevisionRemovedFromReviewFeedEvent>(revisionRemovedFromReviewFeedEventBean.Base);
            revisionRemovedFromReviewFeedEvent.RevisionIds = revisionRemovedFromReviewFeedEventBean.RevisionIds ?? new string[0];

            return revisionRemovedFromReviewFeedEvent;
        }
    }
}