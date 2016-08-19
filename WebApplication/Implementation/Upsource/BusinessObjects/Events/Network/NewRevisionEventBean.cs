using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class NewRevisionEventBean : IEventBean
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
    }
}