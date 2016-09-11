using System;
using System.Collections.Generic;
using System.Linq;
using DomainLogic;
using SKBKontur.BlocksMapping.BlockExtenssions;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models.Converters;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Bucket
{
    public class ReviewBucket : IReviewBucket
    {
        private readonly IReviewConverter reviewConverter;
        private readonly Dictionary<string, Guid> reviewIdMap;
        private readonly Dictionary<string, Guid> userIdMap;

        public ReviewBucket(
            ReviewModel[] reviewModels,
            IReviewConverter reviewConverter)
        {
            Reviews = reviewModels;
            this.reviewConverter = reviewConverter;
            reviewIdMap = reviewModels.ToDictionary(r => r.ExternalId, r => r.Id);
            userIdMap = reviewModels
                .SelectMany(r => r.Authors.Concat(r.Reviewers))
                .Select(r => new { r.ExternalId, r.Id })
                .Distinct()
                .ToDictionary(r => r.ExternalId, r => r.Id);
        }

        public Tracking.Review[] GetDomainModel()
        {
            return Reviews.Select(reviewConverter.Convert).ToArray();
        }

        public ReviewModel[] Reviews { get; private set; }

        public void SetDomainModel(IEnumerable<Tracking.Review> reviews)
        {
            Reviews =
                reviews
                    .Select(r => reviewConverter.Convert(reviewIdMap.SafeGet(r.Id.Item), r, userIdMap))
                    .ToArray();
        }
    }
}