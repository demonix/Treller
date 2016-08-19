using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class ReviewStateChangedFeedEventBean : FeedEventBaseBean
    {
        [JsonProperty("oldState")]
        public ReviewState OldState { get; set; }

        [JsonProperty("newState")]
        public ReviewState NewState { get; set; }
    }
}