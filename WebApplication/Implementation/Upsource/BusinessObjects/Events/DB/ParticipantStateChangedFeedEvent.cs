using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB
{
    [MongoTable("ParticipantStateChangedFeedEvents")]
    public class ParticipantStateChangedFeedEvent : FeedEvent
    {
        [JsonProperty("ParticipantId")]
        public string ParticipantId { get; set; }

        [JsonProperty("OldState")]
        public ParticipantState OldState { get; set; }

        [JsonProperty("NewState")]
        public ParticipantState NewState { get; set; }
    }
}