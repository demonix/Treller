namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Converters
{
    public interface IWebhookConverter
    {
        Webhook Convert(WebhookModel webhookModel);
    }
}