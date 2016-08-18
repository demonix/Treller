using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Objects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class DiscussionFeedEventBean : FeedEventBase
    {
        [JsonProperty("notificationReason")]
        public NotificationReason NotificationReason { get; set; }

        [JsonProperty("discussionId")]
        public string DiscussionId { get; set; }

        [JsonProperty("commentId")]
        public string CommentId { get; set; }

        [JsonProperty("commentText")]
        public string CommentText { get; set; }
    }
}