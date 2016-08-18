using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class ReviewStoppedBranchTrackingFeedEventBean : FeedEventBase
    {
        [JsonProperty("branch")]
        public string Branch { get; set; }
    }
}