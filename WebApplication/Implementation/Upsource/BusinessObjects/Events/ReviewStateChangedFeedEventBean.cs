using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Objects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class ReviewStateChangedFeedEventBean : FeedEventBase
    {
        [JsonProperty("oldState")]
        public ReviewState OldState { get; set; }

        [JsonProperty("newState")]
        public ReviewState NewState { get; set; }
    }
}