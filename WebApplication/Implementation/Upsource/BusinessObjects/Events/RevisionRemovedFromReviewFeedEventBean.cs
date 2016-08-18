using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class RevisionRemovedFromReviewFeedEventBean : FeedEventBase
    {
        [JsonProperty("revisionIds")]
        public string[] RevisionIds { get; set; }
    }
}