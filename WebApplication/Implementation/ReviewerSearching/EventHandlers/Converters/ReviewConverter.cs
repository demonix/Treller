using System;
using System.Collections.Generic;
using System.Linq;
using DomainLogic;
using Microsoft.FSharp.Collections;
using SKBKontur.BlocksMapping.BlockExtenssions;
using SKBKontur.Infrastructure.Common;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects;
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
                Authors = review.Authors.Select(u => userConverter.Convert(userIdMap.SafeGet(u.Id.Item), u, review.Timestamp.Item)).ToList(),
                Reviewers = review.Reviewers.Select(u => userConverter.Convert(userIdMap.SafeGet(u.Id.Item), u, review.Timestamp.Item)).ToList(),
                State = review.State.IsOpen ? ReviewState.Open : ReviewState.Closed
            };
        }

        public Tracking.Review ConvertToDomain(ReviewModel reviewModel)
        {
            var externalId = CommonTypes.ExternalId.NewExternalId(reviewModel.ExternalId);
            var timestamp = Tracking.Timestamp.NewTimestamp(reviewModel.Timestamp);
            var authors = reviewModel.Authors.Select(userConverter.Convert);
            var reviewers = reviewModel.Reviewers.Select(userConverter.Convert);
            var reviewState = reviewModel.State == ReviewState.Open ? Tracking.ReviewState.Open : Tracking.ReviewState.Closed;
            return new Tracking.Review(externalId, timestamp, ListModule.OfSeq(authors), ListModule.OfSeq(reviewers), reviewState);
        }

        public ReviewModel[] Convert(List<Review> reviews, List<ReviewLink> reviewLinks, List<ReviewerSearchingUser> reviewerSearchingUsers)
        {
            var reviewLinkGroup = reviewLinks.ToLookup(l => l.ReviewId);
            var users = reviewerSearchingUsers.ToDictionary(u => u.Id, Convert);

            return reviews
                .Select(r => new ReviewModel
                {
                    Id = r.Id,
                    Timestamp = r.Timestamp,
                    ExternalId = r.ExternalReviewId,
                    State = r.State,
                    Authors = Convert(reviewLinkGroup[r.Id], users, ParticipantRole.Author),
                    Reviewers = Convert(reviewLinkGroup[r.Id], users, ParticipantRole.Reviewer)
                })
                .ToArray();
        }

        public Tuple<List<Review>, List<ReviewLink>, List<ReviewerSearchingUser>> Convert(ReviewModel[] reviewModels)
        {
            var reviews = new List<Review>();
            var reviewLinks = new List<ReviewLink>();

            foreach (var reviewModel in reviewModels)
            {
                var review = ConvertToDb(reviewModel);
                reviews.Add(review);

                var authorLinks = reviewModel.Authors.Select(a => CreateReviewLink(a.Id, reviewModel.Id, ParticipantRole.Author));
                var reviewerLinks = reviewModel.Reviewers.Select(a => CreateReviewLink(a.Id, reviewModel.Id, ParticipantRole.Reviewer));

                reviewLinks.AddRange(authorLinks.Concat(reviewerLinks));
            }

            var reviewerSearchingUsers = reviewModels.SelectMany(r => r.Authors.Concat(r.Reviewers))
                .GroupBy(u => u.Id)
                .Select(g => g.OrderByDescending(u => u.Timestamp).First())
                .Select(Convert)
                .ToList();

            return Tuple.Create(reviews, reviewLinks, reviewerSearchingUsers);
        }

        private static Review ConvertToDb(ReviewModel reviewModel)
        {
            return new Review
            {
                Id = reviewModel.Id,
                Timestamp = reviewModel.Timestamp,
                State = reviewModel.State,
                ExternalReviewId = reviewModel.ExternalId
            };
        }

        private ReviewLink CreateReviewLink(Guid userId, Guid reviewId, ParticipantRole participantRole)
        {
            return new ReviewLink
            {
                Id = guidFactory.Create(),
                UserId = userId,
                ParticipantRole = participantRole,
                ReviewId = reviewId
            };
        }

        private static List<UserModel> Convert(IEnumerable<ReviewLink> reviewLinks, Dictionary<Guid, UserModel> users, ParticipantRole participantRole)
        {
            return reviewLinks
                .Where(l => l.ParticipantRole == participantRole)
                .Select(l => users[l.UserId])
                .ToList();
        }

        private static UserModel Convert(ReviewerSearchingUser reviewerSearchingUser)
        {
            return new UserModel
            {
                Id = reviewerSearchingUser.Id,
                ExternalId = reviewerSearchingUser.ExtnernalUserId,
                Name = reviewerSearchingUser.Name,
                Timestamp = reviewerSearchingUser.Timestamp
            };
        }

        private static ReviewerSearchingUser Convert(UserModel userModel)
        {
            return new ReviewerSearchingUser
            {
                Id = userModel.Id,
                ExtnernalUserId = userModel.ExternalId,
                Name = userModel.Name,
                Timestamp = userModel.Timestamp
            };
        }
    }
}