using System;
using System.Collections.Generic;
using DomainLogic;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Converters
{
    public interface IReviewConverter
    {
        ReviewModel Convert(Guid reviewId, Tracking.Review review, Dictionary<string, Guid> userIdMap);
        Tracking.Review ConvertToDomain(ReviewModel reviewModel);

        ReviewModel[] Convert(List<Review> reviews, List<ReviewLink> reviewLinks, List<ReviewerSearchingUser> reviewerSearchingUsers);
        Tuple<List<Review>, List<ReviewLink>, List<ReviewerSearchingUser>> Convert(ReviewModel[] reviewModels);
    }
}