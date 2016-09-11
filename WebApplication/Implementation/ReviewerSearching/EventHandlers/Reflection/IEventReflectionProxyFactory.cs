using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Reflection
{
    public interface IEventReflectionProxyFactory
    {
        IEventReflectionProxy Create(Webhook webhook);
    }
}