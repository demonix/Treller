using System;
using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Objects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.Extensions;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class FeedEventBean : IEvent
    {
        [JsonProperty("userId")]
        public UserIdBean Initiator { get; set; } //note: по описанию тоже что и Actor, этот параметр optional

        [JsonProperty("userIds")]
        public UserIdBean[] Receivers { get; set; }

        [JsonProperty("reviewNumber")]
        public int? ReviewNumber { get; set; }

        [JsonProperty("date")]
        public double JavaTimestamp { get; set; }

        [JsonProperty("actor")]
        public UserIdBean Actor { get; set; } //note: по описанию тоже что и Initiator, этот параметр required

        [JsonProperty("feedEventId")]
        public string FeedEventId { get; set; }

        public long Timestamp => JavaTimestamp.ToUtcTicks();
        public string Id => string.IsNullOrWhiteSpace(FeedEventId) ? Guid.NewGuid().ToString() : FeedEventId;
    }
}