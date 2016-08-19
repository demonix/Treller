using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class NewParticipantInReviewFeedEventConverter : IEventConverter<NewParticipantInReviewFeedEventBean, NewParticipantInReviewFeedEvent>
    {
        private readonly IFeedEventConverter feedEventConverter;

        public NewParticipantInReviewFeedEventConverter(IFeedEventConverter feedEventConverter)
        {
            this.feedEventConverter = feedEventConverter;
        }

        public NewParticipantInReviewFeedEvent Convert(NewParticipantInReviewFeedEventBean newParticipantInReviewFeedEventBean)
        {
            var newParticipantInReviewFeedEvent = feedEventConverter.Convert<NewParticipantInReviewFeedEvent>(newParticipantInReviewFeedEventBean.Base);
            newParticipantInReviewFeedEvent.ParticipantId = newParticipantInReviewFeedEventBean.Participant.Id;
            newParticipantInReviewFeedEvent.Role = newParticipantInReviewFeedEventBean.Role;

            return newParticipantInReviewFeedEvent;
        }
    }
}