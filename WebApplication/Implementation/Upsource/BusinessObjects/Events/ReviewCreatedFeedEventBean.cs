using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class ReviewCreatedFeedEventBean : FeedEventBase
    {
        [JsonProperty("revisions")]
        public string[] Revisions { get; set; }
    }
}