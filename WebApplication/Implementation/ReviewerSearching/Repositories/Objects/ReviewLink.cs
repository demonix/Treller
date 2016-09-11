using System;
using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects
{
    [MongoTable("ReviewLinks")]
    public class ReviewLink : IDbEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("ReviewId")]
        public Guid ReviewId { get; set; }

        [BsonElement("UserId")]
        public Guid UserId { get; set; }

        [BsonElement("ParticipantRole")]
        public ParticipantRole ParticipantRole { get; set; }
    }
}