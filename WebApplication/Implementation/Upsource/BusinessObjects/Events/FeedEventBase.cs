using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class FeedEventBase : IEvent
    {
        [JsonProperty("base")]
        public FeedEventBean Base { get; set; }

        public long Timestamp => Base.Timestamp;
        public string Id => Base.Id;
    }
}