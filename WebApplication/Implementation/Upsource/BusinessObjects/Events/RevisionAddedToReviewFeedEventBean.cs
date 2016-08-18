using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class RevisionAddedToReviewFeedEventBean : FeedEventBase
    {
        [JsonProperty("revisionIds")]
        public string[] RevisionIds { get; set; }
    }
}