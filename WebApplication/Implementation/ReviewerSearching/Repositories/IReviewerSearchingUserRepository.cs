using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.Mongo;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories
{
    public interface IReviewerSearchingUserRepository
    {
        Task<List<ReviewerSearchingUser>> SelectAsync(Guid[] userIds);
        Task ApplyAsync(ChangeSet<ReviewerSearchingUser> reviewSearchingUserChangeSet);
    }
}