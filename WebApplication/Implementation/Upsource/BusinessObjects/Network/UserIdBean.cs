using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Network
{
    public class UserIdBean
    {
        [JsonProperty("userId")]
        public string Id { get; set; }

        [JsonProperty("userName")]
        public string Name { get; set; }

        [JsonProperty("userEmail")]
        public string Email { get; set; }
    }
}