using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SKBKontur.Treller.WebApplication.Implementation.Mongo;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Repositories
{
    public class UpsourceEventRepository : IUpsourceEventRepository
    {
        private readonly IMongoClientProvider mongoClientProvider;

        public UpsourceEventRepository(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }

        public Task InsertAsync(UpsourceEvent upsourceEvent)
        {
            return mongoClientProvider
                .GetCollection<UpsourceEvent>()
                .InsertOneAsync(upsourceEvent);
        }

        public Task<List<UpsourceEvent>> EnumerateAsync(long afterTimestamp, int count)
        {
            return mongoClientProvider
                .GetCollection<UpsourceEvent>()
                .Find(ue => ue.Timestamp > afterTimestamp)
                .Limit(count)
                //todo: по идее это можно не делать ,если будет индекс по Timestamp - проверить гипотезу
                .SortBy(ue => ue.Timestamp)
                .ToListAsync();
        }
    }
}