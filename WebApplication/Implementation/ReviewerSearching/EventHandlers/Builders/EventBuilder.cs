using DomainLogic;
using SKBKontur.Infrastructure.Common;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Builders
{
    public class EventBuilder : IEventBuilder
    {
        private readonly ITimestampConverter timestampConverter;

        public EventBuilder(
            ITimestampConverter timestampConverter)
        {
            this.timestampConverter = timestampConverter;
        }

        public Tracking.Event Build(FeedEventBean feedEventBean, Tracking.EventData eventData)
        {
            var externalReviewId = CommonTypes.ExternalId.NewExternalId(feedEventBean.FeedEventId);
            var utcTicks = timestampConverter.ToUtcTicks(feedEventBean.JavaTimestamp);
            var eventTimestamp = Tracking.Timestamp.NewTimestamp(utcTicks);

            return new Tracking.Event(externalReviewId, eventTimestamp, eventData);
        }
    }
}