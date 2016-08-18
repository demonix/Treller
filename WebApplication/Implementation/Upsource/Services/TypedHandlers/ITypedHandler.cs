namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services.TypedHandlers
{
    public interface ITypedHandler<in TEventData>
    {
        void Handle(TEventData eventData);
    }
}