using System;
using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects
{
    [MongoTable("Reviews")]
    public class Review
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("ExternalReviewId")]
        public string ExternalReviewId { get; set; }

        [BsonElement("State")]
        public ReviewState State { get; set; }

        [BsonElement("Timestamp")]
        public long Timestamp { get; set; }
    }
}