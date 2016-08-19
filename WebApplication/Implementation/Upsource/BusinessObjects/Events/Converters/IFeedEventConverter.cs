using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public interface IFeedEventConverter
    {
        TFeedEvent Convert<TFeedEvent>(FeedEventBean feedEventBean) where TFeedEvent : FeedEvent, new();
    }
}