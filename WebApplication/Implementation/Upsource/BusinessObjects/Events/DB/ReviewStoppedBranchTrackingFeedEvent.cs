using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    [MongoTable("ReviewStoppedBranchTrackingFeedEvents")]
    public class ReviewStoppedBranchTrackingFeedEvent : FeedEvent
    {
        [BsonElement("Branch")]
        public string Branch { get; set; }
    }
}