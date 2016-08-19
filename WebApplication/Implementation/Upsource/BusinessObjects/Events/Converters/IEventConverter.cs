using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public interface IEventConverter<in TEventBean, out TEvent>
        where TEvent : IEvent
        where TEventBean : IEventBean
    {
        TEvent Convert(TEventBean eventBean);
    }
}