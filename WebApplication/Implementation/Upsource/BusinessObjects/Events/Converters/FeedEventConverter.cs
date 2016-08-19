using System.Linq;
using SKBKontur.Infrastructure.Common;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class FeedEventConverter : IFeedEventConverter
    {
        private readonly IGuidFactory guidFactory;
        private readonly ITimestampConverter timestampConverter;

        public FeedEventConverter(
            IGuidFactory guidFactory,
            ITimestampConverter timestampConverter)
        {
            this.guidFactory = guidFactory;
            this.timestampConverter = timestampConverter;
        }

        public TFeedEvent Convert<TFeedEvent>(FeedEventBean feedEventBean) where TFeedEvent : FeedEvent, new()
        {
            return new TFeedEvent
            {
                Id = string.IsNullOrWhiteSpace(feedEventBean.FeedEventId) ? guidFactory.Create().ToString() : feedEventBean.FeedEventId,
                ActorId = feedEventBean.Actor.Id,
                InitiatorId = feedEventBean.Initiator?.Id,
                ReceiverIds = feedEventBean.Receivers?.Select(x => x.Id).ToArray() ?? new string[0],
                ReviewNumber = feedEventBean.ReviewNumber,
                Timestamp = timestampConverter.ToUtcTicks(feedEventBean.JavaTimestamp)
            };
        }
    }
}