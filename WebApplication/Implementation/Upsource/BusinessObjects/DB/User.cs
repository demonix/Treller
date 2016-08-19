using MongoDB.Bson.Serialization.Attributes;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.DB
{
    public class UpsourceUser
    {
        [BsonElement("Id")]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
    }
}