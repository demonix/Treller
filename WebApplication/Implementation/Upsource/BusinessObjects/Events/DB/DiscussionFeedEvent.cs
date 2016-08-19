using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    [MongoTable("DiscussionFeedEvents")]
    public class DiscussionFeedEvent : FeedEvent
    {
        [BsonElement("NotificationReason")]
        public NotificationReason NotificationReason { get; set; }

        [BsonElement("DiscussionId")]
        public string DiscussionId { get; set; }

        [BsonElement("CommentId")]
        public string CommentId { get; set; }

        [BsonElement("CommentText")]
        public string CommentText { get; set; }
    }
}