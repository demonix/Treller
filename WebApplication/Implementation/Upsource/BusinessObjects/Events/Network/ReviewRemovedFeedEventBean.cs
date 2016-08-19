using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class ReviewRemovedFeedEventBean : FeedEventBaseBean
    {
        [JsonProperty("reviewId")]
        public string ReviewId { get; set; }
    }
}