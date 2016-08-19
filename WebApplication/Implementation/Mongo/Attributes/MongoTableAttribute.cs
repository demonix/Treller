using System;

namespace SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes
{
    public class MongoTableAttribute : Attribute
    {
        public string DbName { get; private set; }

        public MongoTableAttribute(string dbName)
        {
            DbName = dbName;
        }
    }
}