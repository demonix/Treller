using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SKBKontur.Treller.WebApplication.Implementation.Mongo;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories
{
    public class ReviewerSearchingUserRepository : IReviewerSearchingUserRepository
    {
        private readonly IMongoClientProvider mongoClientProvider;

        public ReviewerSearchingUserRepository(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }

        public Task<List<ReviewerSearchingUser>> SelectAsync(Guid[] userIds)
        {
            return mongoClientProvider
                .GetCollection<ReviewerSearchingUser>()
                .Find(u => userIds.Contains(u.Id))
                .ToListAsync();
        }

        public Task ApplyAsync(ChangeSet<ReviewerSearchingUser> reviewSearchingUserChangeSet)
        {
            return mongoClientProvider.ApplyAsync(reviewSearchingUserChangeSet);
        }
    }
}