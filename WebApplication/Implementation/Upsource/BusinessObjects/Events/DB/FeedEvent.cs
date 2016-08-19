using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    public class FeedEvent : IEvent
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("Timestamp")]
        public long Timestamp { get; set; }

        [BsonElement("InitiatorId")]
        public string InitiatorId { get; set; } //note: по описанию тоже что и Actor, этот параметр optional

        [BsonElement("ReceiverIds")]
        public string[] ReceiverIds { get; set; }

        [BsonElement("ReviewNumber")]
        public int? ReviewNumber { get; set; }

        [BsonElement("ActorId")]
        public string ActorId { get; set; } //note: по описанию тоже что и Initiator, этот параметр required
    }
}