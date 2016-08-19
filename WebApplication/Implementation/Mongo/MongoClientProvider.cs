using System;
using System.Collections.Concurrent;
using System.Reflection;
using MongoDB.Driver;
using SKBKontur.Treller.WebApplication.Implementation.Mongo.Attributes;

namespace SKBKontur.Treller.WebApplication.Implementation.Mongo
{
    public class MongoClientProvider : IMongoClientProvider
    {
        private readonly IMongoDatabase db;
        private readonly ConcurrentDictionary<Type, string> dbNameMap;

        public MongoClientProvider()
        {
            //todo: put to settings | hardcode masta
            const string connectionString = "mongodb://localhost/treller?safe=true;maxpoolsize=10000";
            const string dbName = "treller";

            var client = new MongoClient(connectionString);
            db = client.GetDatabase(dbName);

            dbNameMap = new ConcurrentDictionary<Type, string>();
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            var entityType = typeof(TEntity);
            var dbName = dbNameMap.GetOrAdd(entityType, type => ((MongoTableAttribute)type.GetCustomAttribute(typeof(MongoTableAttribute))).DbName);

            return GetCollection<TEntity>(dbName);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
        {
            return db.GetCollection<TEntity>(name);
        }
    }
}