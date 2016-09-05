using SKBKontur.Infrastructure.Common;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Converters;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Factories
{
    public class UpsourceEventFactory : IUpsourceEventFactory
    {
        private readonly IGuidFactory guidFactory;
        private readonly IDateTimeFactory dateTimeFactory;
        private readonly IWebhookConverter webhookConverter;

        public UpsourceEventFactory(
            IGuidFactory guidFactory,
            IDateTimeFactory dateTimeFactory,
            IWebhookConverter webhookConverter)
        {
            this.guidFactory = guidFactory;
            this.dateTimeFactory = dateTimeFactory;
            this.webhookConverter = webhookConverter;
        }

        public UpsourceEvent Create(WebhookModel webhookModel)
        {
            return new UpsourceEvent
            {
                Id = guidFactory.Create(),
                Timestamp = dateTimeFactory.UtcTicks,
                Webhook = webhookConverter.Convert(webhookModel)
            };
        }
    }
}