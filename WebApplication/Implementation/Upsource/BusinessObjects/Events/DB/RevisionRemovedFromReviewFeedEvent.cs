using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    [MongoTable("RevisionRemovedFromReviewFeedEvents")]
    public class RevisionRemovedFromReviewFeedEvent : FeedEvent
    {
        [BsonElement("RevisionIds")]
        public string[] RevisionIds { get; set; }
    }
}