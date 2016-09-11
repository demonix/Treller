using System;
using System.Collections.Generic;
using DomainLogic;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Converters
{
    public interface IReviewConverter
    {
        ReviewModel Convert(Guid reviewId, Tracking.Review review, Dictionary<string, Guid> userIdMap);
        Tracking.Review Convert(ReviewModel reviewModel);
    }
}