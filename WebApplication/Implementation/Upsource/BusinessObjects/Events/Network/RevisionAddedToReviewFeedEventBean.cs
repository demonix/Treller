using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class RevisionAddedToReviewFeedEventBean : FeedEventBaseBean
    {
        [JsonProperty("revisionIds")]
        public string[] RevisionIds { get; set; }
    }
}