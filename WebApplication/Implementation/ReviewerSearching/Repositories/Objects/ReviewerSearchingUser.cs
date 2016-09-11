using System;
using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects
{
    [MongoTable("ReviewerSearchingUsers")]
    public class ReviewerSearchingUser : IDbEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("ExtnernalUserId")]
        public string ExtnernalUserId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Timestamp")]
        public long Timestamp { get; set; }
    }
}