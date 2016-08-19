using Newtonsoft.Json;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class FeedEventBaseBean : IEventBean
    {
        [JsonProperty("base")]
        public FeedEventBean Base { get; set; }
    }
}