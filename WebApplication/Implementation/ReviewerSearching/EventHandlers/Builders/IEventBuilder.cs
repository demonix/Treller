using DomainLogic;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Builders
{
    public interface IEventBuilder
    {
        Tracking.Event Build(FeedEventBean feedEventBean, Tracking.EventData eventData);
    }
}