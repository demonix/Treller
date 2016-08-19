using MongoDB.Driver;

namespace SKBKontur.Treller.WebApplication.Implementation.Mongo
{
    public interface IMongoClientProvider
    {
        IMongoCollection<TEntity> GetCollection<TEntity>();
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
    }
}