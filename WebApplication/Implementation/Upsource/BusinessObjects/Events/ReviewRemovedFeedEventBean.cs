using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class ReviewRemovedFeedEventBean : FeedEventBase
    {
        [JsonProperty("reviewId")]
        public string ReviewId { get; set; }
    }
}