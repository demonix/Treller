using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.Mongo;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Repository
{
    public class UpsourceEventRepository : IUpsourceEventRepository
    {
        private readonly IMongoClientProvider mongoClientProvider;

        public UpsourceEventRepository(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }

        public async Task InsertAsync(UpsourceEvent upsourceEvent)
        {
            await mongoClientProvider
                .GetCollection<UpsourceEvent>()
                .InsertOneAsync(upsourceEvent)
                .ConfigureAwait(true);
        }
    }
}