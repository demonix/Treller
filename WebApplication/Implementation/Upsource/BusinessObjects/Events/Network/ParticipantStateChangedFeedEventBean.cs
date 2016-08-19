using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class ParticipantStateChangedFeedEventBean : FeedEventBaseBean
    {

        [JsonProperty("participant")]
        public UserIdBean Participant { get; set; }

        [JsonProperty("oldState")]
        public ParticipantState OldState { get; set; }

        [JsonProperty("newState")]
        public ParticipantState NewState { get; set; }
    }
}