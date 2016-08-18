using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public interface IEventHandler
    {
        void Handle(WebhookModel webhookModel);
    }
}