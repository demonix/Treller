using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Objects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Objects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class NewParticipantInReviewFeedEventBean : FeedEventBase
    {
        [JsonProperty("participant")]
        public UserIdBean Participant { get; set; }

        [JsonProperty("role")]
        public ParticipantRole Role { get; set; }
    }
}