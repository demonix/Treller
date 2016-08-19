using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class ReviewCreatedFeedEventBean : FeedEventBaseBean
    {
        [JsonProperty("revisions")]
        public string[] Revisions { get; set; }
    }
}