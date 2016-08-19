using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    [MongoTable("NewParticipantInReviewFeedEvents")]
    public class NewParticipantInReviewFeedEvent : FeedEvent
    {
        [BsonElement("ParticipantId")]
        public string ParticipantId { get; set; }

        [BsonElement("Role")]
        public ParticipantRole Role { get; set; }
    }
}