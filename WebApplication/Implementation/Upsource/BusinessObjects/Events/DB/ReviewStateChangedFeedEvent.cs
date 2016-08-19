using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    [MongoTable("ReviewStateChangedFeedEvents")]
    public class ReviewStateChangedFeedEvent : FeedEvent
    {
        [BsonElement("OldState")]
        public ReviewState OldState { get; set; }

        [BsonElement("NewState")]
        public ReviewState NewState { get; set; }
    }
}