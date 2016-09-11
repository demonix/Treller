using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SKBKontur.Treller.WebApplication.Implementation.Mongo;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories
{
    public class ReviewLinkRepository : IReviewLinkRepository
    {
        private readonly IMongoClientProvider mongoClientProvider;

        public ReviewLinkRepository(IMongoClientProvider mongoClientProvider)
        {
            this.mongoClientProvider = mongoClientProvider;
        }


        public Task<List<ReviewLink>> SelectAsync(Guid[] reviewIds)
        {
            return mongoClientProvider
                .GetCollection<ReviewLink>()
                .Find(l => reviewIds.Contains(l.ReviewId))
                .ToListAsync();
        }

        public Task ApplyAsync(ChangeSet<ReviewLink> reviewLinkChangeSet)
        {
            return mongoClientProvider.ApplyAsync(reviewLinkChangeSet);
        }
    }
}