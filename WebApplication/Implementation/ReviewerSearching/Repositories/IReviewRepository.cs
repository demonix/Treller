﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories
{
    public interface IReviewRepository
    {
        Task<List<Review>> SelectAsync(string[] externalReviewIds);
    }
}