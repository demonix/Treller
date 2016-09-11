using SKBKontur.Infrastructure.ContainerConfiguration;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Reflection
{
    public class EventReflectionProxyFactory : IEventReflectionProxyFactory
    {
        private readonly IContainer container;
        private readonly IWebhookEventParser webhookEventParser;

        public EventReflectionProxyFactory(IContainer container, IWebhookEventParser webhookEventParser)
        {
            this.container = container;
            this.webhookEventParser = webhookEventParser;
        }

        public IEventReflectionProxy Create(Webhook webhook)
        {
            var dataType = webhookEventParser.Parse(webhook.DataType);
            return new EventReflectionProxy(webhook.SerializedData, dataType, container);
        }
    }
}