using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.Mongo;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Repository
{
    public class EventCommandRepository : IEventCommandRepository
    {
        private readonly IMongoClientProvider mongoClientProvider;

        public EventCommandRepository(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }

        public async Task InsertAsync<TEvent>(TEvent @event)
        {
            await mongoClientProvider.GetCollection<TEvent>().InsertOneAsync(@event).ConfigureAwait(false);
        }
    }
}