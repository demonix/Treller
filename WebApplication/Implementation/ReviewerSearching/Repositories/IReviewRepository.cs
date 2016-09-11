using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SKBKontur.Treller.WebApplication.Implementation.Mongo;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories
{
    public interface IReviewRepository
    {
        Task<List<Review>> SelectAsync(string[] externalReviewIds);
        Task ApplyAsync(ChangeSet<Review> changeSet);
    }

    public class ReviewRepository : IReviewRepository
    {
        private readonly IMongoClientProvider mongoClientProvider;

        public ReviewRepository(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }

        public Task<List<Review>> SelectAsync(string[] externalReviewIds)
        {
            return mongoClientProvider
                .GetCollection<Review>()
                .Find(r => externalReviewIds.Contains(r.ExternalReviewId))
                .ToListAsync();
        }

        public Task ApplyAsync(ChangeSet<Review> changeSet)
        {
            return mongoClientProvider.ApplyAsync(changeSet);
        }
    }
}