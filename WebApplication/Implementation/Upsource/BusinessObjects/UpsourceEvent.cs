using System;
using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects
{
    [MongoTable("UpsourceEvents")]
    public class UpsourceEvent
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("Timestamp")]
        public long Timestamp { get; set; }

        [BsonElement("Webhook")]
        public Webhook Webhook { get; set; } 
    }
}