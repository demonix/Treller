using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Objects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Objects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class ParticipantStateChangedFeedEventBean : FeedEventBase
    {

        [JsonProperty("participant")]
        public UserIdBean Participant { get; set; }

        [JsonProperty("oldState")]
        public ParticipantState OldState { get; set; }

        [JsonProperty("newState")]
        public ParticipantState NewState { get; set; }
    }
}