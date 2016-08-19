using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class ReviewStoppedBranchTrackingFeedEventBean : FeedEventBaseBean
    {
        [JsonProperty("branch")]
        public string Branch { get; set; }
    }
}