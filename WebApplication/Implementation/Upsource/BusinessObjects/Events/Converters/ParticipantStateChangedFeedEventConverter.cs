using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class ParticipantStateChangedFeedEventConverter : IParticipantStateChangedFeedEventConverter
    {
        private readonly IFeedEventConverter feedEventConverter;

        public ParticipantStateChangedFeedEventConverter(IFeedEventConverter feedEventConverter)
        {
            this.feedEventConverter = feedEventConverter;
        }

        public ParticipantStateChangedFeedEvent Convert(ParticipantStateChangedFeedEventBean participantStateChangedFeedEventBean)
        {
            var participantStateChangedFeedEvent = feedEventConverter.Convert<ParticipantStateChangedFeedEvent>(participantStateChangedFeedEventBean.Base);
            participantStateChangedFeedEvent.ParticipantId = participantStateChangedFeedEventBean.Participant.Id;
            participantStateChangedFeedEvent.NewState = participantStateChangedFeedEventBean.NewState;
            participantStateChangedFeedEvent.OldState = participantStateChangedFeedEventBean.OldState;

            return participantStateChangedFeedEvent;
        }
    }
}