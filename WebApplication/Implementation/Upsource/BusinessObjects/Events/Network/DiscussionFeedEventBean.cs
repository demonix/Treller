using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class DiscussionFeedEventBean : FeedEventBaseBean
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