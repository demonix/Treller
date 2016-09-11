using System;
using DomainLogic;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Base;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Builders;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Converters;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers
{
    public class NewParticipantInReviewFeedEventBeanHandler : IEventBeanHandler<NewParticipantInReviewFeedEventBean>
    {
        private readonly IUserConverter userConverter;
        private readonly IEventHandler eventHandler;
        private readonly IEventBuilder eventBuilder;

        public NewParticipantInReviewFeedEventBeanHandler(
            IUserConverter userConverter,
            IEventHandler eventHandler,
            IEventBuilder eventBuilder
            )
        {
            this.userConverter = userConverter;
            this.eventHandler = eventHandler;
            this.eventBuilder = eventBuilder;
        }

        public ReviewModel[] Handle(NewParticipantInReviewFeedEventBean eventData, ReviewModel[] reviewModels)
        {
            var participantFs = userConverter.ConvertToDomain(eventData.Participant);
            var participantRoleFs = Convert(eventData.Role);
            var newParticipantInReviewFs = new Tracking.NewParticipantInReview(participantFs, participantRoleFs);
            var eventDataFs = Tracking.EventData.NewNewParticipantInReview(newParticipantInReviewFs);
            var @event = eventBuilder.Build(eventData.Base, eventDataFs);

            return eventHandler.Apply(@event, reviewModels);
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