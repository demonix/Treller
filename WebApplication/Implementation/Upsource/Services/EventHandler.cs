using SKBKontur.Infrastructure.ContainerConfiguration;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.Services.TypedHandlers;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public class EventHandler : IEventHandler
    {
        private readonly IWebhookEventParser webhookEventParser;
        private readonly IContainer container;

        public EventHandler(IWebhookEventParser webhookEventParser, IContainer container)
        {
            this.webhookEventParser = webhookEventParser;
            this.container = container;
        }

        public void Handle(WebhookModel webhookModel)
        {
            var dataPack = webhookEventParser.Parse(webhookModel);
            var typedHandlerGenericType = typeof(ITypedHandler<>);
            var typedHandlerType = typedHandlerGenericType.MakeGenericType(dataPack.Key);
            var typedHandler = container.Get(typedHandlerType);
            var handleMethod = typedHandlerType.GetMethod("Handle");
            handleMethod.Invoke(typedHandler, new[] { dataPack.Value });
        }
    }
}