using MongoDB.Bson.Serialization.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    [MongoTable("PullRequestMergedFeedEvents")]
    public class PullRequestMergedFeedEvent : FeedEvent
    {
        [BsonElement("BranchName")]
        public string BranchName { get; set; }
    }
}