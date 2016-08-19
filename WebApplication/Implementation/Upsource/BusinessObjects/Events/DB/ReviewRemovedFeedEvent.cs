using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    [MongoTable("ReviewRemovedFeedEvents")]
    public class ReviewRemovedFeedEvent : FeedEvent
    {
        [BsonElement("ReviewId")]
        public string ReviewId { get; set; }
    }
}