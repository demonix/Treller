using MongoDB.Bson.Serialization.Attributes;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects
{
    public class Webhook
    {
        [BsonElement("MajorVersion")]
        public int MajorVersion { get; set; }

        [BsonElement("MinorVersion")]
        public int MinorVersion { get; set; }

        [BsonElement("ProjectId")]
        public string ProjectId { get; set; }

        [BsonElement("DataType")]
        public string DataType { get; set; }

        [BsonElement("SerializedData")]
        public string SerializedData { get; set; }
    }
}