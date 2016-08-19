using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    [MongoTable("NewRevisionEvents")]
    public class NewRevisionEvent : IEvent
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("Branches")]
        public string[] Branches { get; set; }

        [BsonElement("AuthorId")]
        public string AuthorId { get; set; }

        [BsonElement("CommitMessage")]
        public string CommitMessage { get; set; }

        [BsonElement("Timestamp")]
        public long Timestamp { get; set; }
    }
}