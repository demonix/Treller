using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class NewParticipantInReviewFeedEventBean : FeedEventBaseBean
    {
        [JsonProperty("participant")]
        public UserIdBean Participant { get; set; }

        [JsonProperty("role")]
        public ParticipantRole Role { get; set; }
    }
}