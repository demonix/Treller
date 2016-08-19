using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class DiscussionFeedEventConverter : IEventConverter<DiscussionFeedEventBean, DiscussionFeedEvent>
    {
        private readonly IFeedEventConverter feedEventConverter;

        public DiscussionFeedEventConverter(IFeedEventConverter feedEventConverter)
        {
            this.feedEventConverter = feedEventConverter;
        }

        public DiscussionFeedEvent Convert(DiscussionFeedEventBean discussionFeedEventBean)
        {
            var discussionFeedEvent = feedEventConverter.Convert<DiscussionFeedEvent>(discussionFeedEventBean.Base);
            discussionFeedEvent.CommentId = discussionFeedEventBean.CommentId;
            discussionFeedEvent.CommentText = discussionFeedEventBean.CommentText;
            discussionFeedEvent.DiscussionId = discussionFeedEventBean.DiscussionId;
            discussionFeedEvent.NotificationReason = discussionFeedEventBean.NotificationReason;

            return discussionFeedEvent;
        }
    }
}