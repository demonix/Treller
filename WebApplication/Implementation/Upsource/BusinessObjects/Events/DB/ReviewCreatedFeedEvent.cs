using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    [MongoTable("ReviewCreatedFeedEvents")]
    public class ReviewCreatedFeedEvent : FeedEvent
    {
        [BsonElement("Revisions")]
        public string[] Revisions { get; set; }
    }
}