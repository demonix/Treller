namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Factories
{
    public interface IUpsourceEventFactory
    {
        UpsourceEvent Create(WebhookModel webhookModel);
    }
}