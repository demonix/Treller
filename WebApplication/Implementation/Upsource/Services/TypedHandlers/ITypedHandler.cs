using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services.TypedHandlers
{
    public interface ITypedHandler<in TEventBean> where TEventBean : IEventBean
    {
        void Handle(TEventBean eventData);
    }
}