using System;
using System.Linq;
using DomainLogic;
using Microsoft.FSharp.Core;
using SKBKontur.Infrastructure.Common;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Bucket;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models.Converters;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers
{
    public class NewParticipantInReviewFeedEventBeanHandler : IEventBeanHandler<NewParticipantInReviewFeedEventBean>
    {
        private readonly IUserConverter userConverter;
        private readonly ITimestampConverter timestampConverter;
        private readonly IReviewBucketFactory reviewBucketFactory;

        public NewParticipantInReviewFeedEventBeanHandler(
            IUserConverter userConverter,
            ITimestampConverter timestampConverter,
            IReviewBucketFactory reviewBucketFactory
            )
        {
            this.userConverter = userConverter;
            this.timestampConverter = timestampConverter;
            this.reviewBucketFactory = reviewBucketFactory;
        }

        public ReviewModel[] Handle(NewParticipantInReviewFeedEventBean eventData, ReviewModel[] reviewModels)
        {
            var externalReviewIdFs = InfrastructureTypes.ExternalId.NewExternalId(eventData.Base.FeedEventId);
            var utcTicks = timestampConverter.ToUtcTicks(eventData.Base.JavaTimestamp);
            var eventTimestampFs = Tracking.Timestamp.NewTimestamp(utcTicks);

            var participantFs = userConverter.Convert(eventData.Participant);
            var participantRoleFs = Convert(eventData.Role);
            var newParticipantInReviewFs = new Tracking.NewParticipantInReview(participantFs, participantRoleFs);
            var eventDataFs = Tracking.EventData.NewNewParticipantInReview(newParticipantInReviewFs);

            var reviewBucket = reviewBucketFactory.Create(reviewModels);
            var reviewsFs = reviewBucket.GetDomainModel();

            var @event = new Tracking.Event(externalReviewIdFs, eventTimestampFs, eventDataFs);
            var optionReviewsFs = Tracking.applyEvent(@event, reviewsFs).ToArray();
            if (optionReviewsFs.Any(FSharpOption<Tracking.Review>.get_IsNone))
            {
                //todo: сделать нормальное сообщение об ошибке
                throw new InvalidOperationException("Can't apply some events");
            }

            reviewBucket.SetDomainModel(optionReviewsFs.Select(r => r.Value));
            
            return reviewBucket.Reviews;
        }

        private Tracking.ParticipantRole Convert(ParticipantRole participantRole)
        {
            switch (participantRole)
            {
                case ParticipantRole.Author: return Tracking.ParticipantRole.Author;
                case ParticipantRole.Reviewer: return Tracking.ParticipantRole.Reviewer;
                case ParticipantRole.Watcher: return Tracking.ParticipantRole.Watcher;
                default:
                    throw new ArgumentOutOfRangeException(nameof(participantRole), participantRole, null);
            }
        }
    }
}