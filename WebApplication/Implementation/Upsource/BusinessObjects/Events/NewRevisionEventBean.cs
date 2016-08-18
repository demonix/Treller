using System;
using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.Extensions;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class NewRevisionEventBean : IEvent
    {
        [JsonProperty("revisionId")]
        public string RevisionId { get; set; }

        [JsonProperty("branches")]
        public string[] Branches { get; set; }

        [JsonProperty("author")]
        public string AuthorId { get; set; }

        [JsonProperty("message")]
        public string CommitMessage { get; set; }

        [JsonProperty("date")]
        public double? CommitTimestamp { get; set; }

        public long Timestamp => CommitTimestamp?.ToUtcTicks() ?? DateTime.UtcNow.Ticks;
        public string Id => RevisionId;
    }
}