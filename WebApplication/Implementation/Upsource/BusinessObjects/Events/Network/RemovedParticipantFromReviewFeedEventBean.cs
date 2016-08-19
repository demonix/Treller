using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class RemovedParticipantFromReviewFeedEventBean : FeedEventBaseBean
    {
        [JsonProperty("participant")]
        public UserIdBean Participant { get; set; }

        [JsonProperty("formerRole")]
        public ParticipantRole RoleHadBeforeBeingRemoved { get; set; }
    }
}