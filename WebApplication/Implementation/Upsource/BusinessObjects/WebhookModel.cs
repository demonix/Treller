using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects
{
    public class WebhookModel
    {
        [JsonProperty("majorVersion")]
        public int MajorVersion { get; set; }

        [JsonProperty("minorVersion")]
        public int MinorVersion { get; set; }

        [JsonProperty("projectId")]
        public string ProjectId { get; set; }

        [JsonProperty("dataType")]
        public string DataType { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}