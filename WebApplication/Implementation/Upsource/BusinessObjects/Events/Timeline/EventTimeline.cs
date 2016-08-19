using System;
using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Timeline
{
    [MongoTable("EventsTimeline")]
    public class EventTimeline
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("Timestamp")]
        public long Timestamp { get; set; }

        [BsonElement("EventStorageName")]
        public string EventStorageName { get; set; }

        [BsonElement("EventTimestamp")]
        public long EventTimestamp { get; set; }

        [BsonElement("EventId")]
        public string EventId { get; set; }
    }
}