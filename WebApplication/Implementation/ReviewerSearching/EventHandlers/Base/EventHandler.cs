using System;
using System.Linq;
using DomainLogic;
using SKBKontur.BlocksMapping.BlockExtenssions;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Converters;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Base
{
    public class EventHandler : IEventHandler
    {
        private readonly IReviewConverter reviewConverter;

        public EventHandler(IReviewConverter reviewConverter)
        {
            this.reviewConverter = reviewConverter;
            
        }

        public ReviewModel[] Apply(Tracking.Event @event, ReviewModel[] reviewModels)
        {
            var reviewIdMap = reviewModels.ToDictionary(r => r.ExternalId, r => r.Id);
            var userIdMap = reviewModels
                .SelectMany(r => r.Authors.Concat(r.Reviewers))
                .Select(r => new { r.ExternalId, r.Id })
                .Distinct()
                .ToDictionary(r => r.ExternalId, r => r.Id);

            var reviewsFs = reviewModels.Select(reviewConverter.ConvertToDomain).ToArray();

            var optionReviewsFs = Tracking.applyEvent(@event, reviewsFs);

            var reviewArray = optionReviewsFs.ToArray();
            var corruptedReviews = reviewArray.Where(r => r.IsError).ToArray();
            if (corruptedReviews.Length > 0)
            {
                var errorMessage = string.Join("\r\n", corruptedReviews.Select(e => ((CommonTypes.Result<Tracking.Review, string>.Error)e).Item));
                throw new InvalidOperationException(errorMessage);
            }

            var appliedReviewModels = reviewArray
                .Select(r => ((CommonTypes.Result<Tracking.Review, string>.Success)r).Item)
                .Select(r => reviewConverter.Convert(reviewIdMap.SafeGet(r.Id.Item), r, userIdMap))
                .ToArray();

            return appliedReviewModels;
        }
    }
}