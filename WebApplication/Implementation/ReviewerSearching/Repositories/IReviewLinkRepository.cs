using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories
{
    public interface IReviewLinkRepository
    {
        Task<List<ReviewLink>> SelectAsync(Guid[] reviewIds);
    }
}