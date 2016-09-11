using System;
using System.Collections.Generic;
using System.Linq;
using DomainLogic;
using Microsoft.FSharp.Collections;
using SKBKontur.BlocksMapping.BlockExtenssions;
using SKBKontur.Infrastructure.Common;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Converters
{
    public class ReviewConverter : IReviewConverter
    {
        private readonly IGuidFactory guidFactory;
        private readonly IUserConverter userConverter;

        public ReviewConverter(
            IGuidFactory guidFactory,
            IUserConverter userConverter)
        {
            this.guidFactory = guidFactory;
            this.userConverter = userConverter;
        }

        public ReviewModel Convert(Guid reviewId, Tracking.Review review, Dictionary<string, Guid> userIdMap)
        {
            return new ReviewModel
            {
                Id = reviewId == Guid.Empty ? guidFactory.Create() : reviewId,
                ExternalId = review.Id.Item,
                Timestamp = review.Timestamp.Item,
                Authors = review.Authors.Select(u => userConverter.Convert(userIdMap.SafeGet(u.Id.Item), u)).ToList(),
                Reviewers = review.Reviewers.Select(u => userConverter.Convert(userIdMap.SafeGet(u.Id.Item), u)).ToList(),
                State = review.State.IsOpen ? ReviewState.Open : ReviewState.Closed
            };
        }

        public Tracking.Review Convert(ReviewModel reviewModel)
        {
            var externalId = CommonTypes.ExternalId.NewExternalId(reviewModel.ExternalId);
            var timestamp = Tracking.Timestamp.NewTimestamp(reviewModel.Timestamp);
            var authors = reviewModel.Authors.Select(userConverter.Convert);
            var reviewers = reviewModel.Reviewers.Select(userConverter.Convert);
            var reviewState = reviewModel.State == ReviewState.Open ? Tracking.ReviewState.Open : Tracking.ReviewState.Closed;
            return new Tracking.Review(externalId, timestamp, ListModule.OfSeq(authors), ListModule.OfSeq(reviewers), reviewState);
        }
    }
}