using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    [MongoTable("RemovedParticipantFromReviewFeedEvents")]
    public class RemovedParticipantFromReviewFeedEvent : FeedEvent
    {
        [BsonElement("ParticipantId")]
        public string ParticipantId { get; set; }

        [BsonElement("RoleHadBeforeBeingRemoved")]
        public ParticipantRole RoleHadBeforeBeingRemoved { get; set; }
    }
}