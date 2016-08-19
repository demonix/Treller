using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class RemovedParticipantFromReviewFeedEventConverter : IRemovedParticipantFromReviewFeedEventConverter
    {
        private readonly IFeedEventConverter feedEventConverter;

        public RemovedParticipantFromReviewFeedEventConverter(IFeedEventConverter feedEventConverter)
        {
            this.feedEventConverter = feedEventConverter;
        }

        public RemovedParticipantFromReviewFeedEvent Convert(RemovedParticipantFromReviewFeedEventBean removedParticipantFromReviewFeedEventBean)
        {
            var removedParticipantFromReviewFeedEvent = feedEventConverter.Convert<RemovedParticipantFromReviewFeedEvent>(removedParticipantFromReviewFeedEventBean.Base);
            removedParticipantFromReviewFeedEvent.ParticipantId = removedParticipantFromReviewFeedEventBean.Participant.Id;
            removedParticipantFromReviewFeedEvent.RoleHadBeforeBeingRemoved = removedParticipantFromReviewFeedEventBean.RoleHadBeforeBeingRemoved;

            return removedParticipantFromReviewFeedEvent;
        }
    }
}