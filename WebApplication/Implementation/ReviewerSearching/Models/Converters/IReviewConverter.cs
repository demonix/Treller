using System;
using System.Collections.Generic;
using DomainLogic;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models.Converters
{
    public interface IReviewConverter
    {
        ReviewModel Convert(Guid reviewId, Tracking.Review review, Dictionary<string, Guid> userIdMap);
        Tracking.Review Convert(ReviewModel reviewModel);
    }
}