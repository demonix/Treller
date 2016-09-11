using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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

        public async Task ApplyAsync<T>(ChangeSet<T> changeSet) where T : class, IDbEntity
        {
            var collection = GetCollection<T>();
            await collection.InsertManyAsync(changeSet.Created).ConfigureAwait(false);

            foreach (var updated in changeSet.Updated)
            {
                await collection.ReplaceOneAsync(r => r.Id == updated.Id, updated).ConfigureAwait(false);
            }

            var deletedIds = changeSet.Deleted.Select(r => r.Id).ToArray();
            await collection.DeleteManyAsync(r => deletedIds.Contains(r.Id)).ConfigureAwait(false);
        }
    }
}