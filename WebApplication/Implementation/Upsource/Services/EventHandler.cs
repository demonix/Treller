using System;
using System.Threading.Tasks;
using SKBKontur.Infrastructure.ContainerConfiguration;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public class EventHandler : IEventHandler
    {
        private readonly IWebhookEventParser webhookEventParser;
        private readonly IContainer container;
        private readonly IEventNetworkToDbMap eventNetworkToDbMap;
        private readonly IEventService eventService;
        private readonly Type eventConverterGenericType;
        private readonly Type eventServiceType;

        public EventHandler(
            IWebhookEventParser webhookEventParser,
            IContainer container,
            IEventNetworkToDbMap eventNetworkToDbMap,
            IEventService eventService)
        {
            this.webhookEventParser = webhookEventParser;
            this.container = container;
            this.eventNetworkToDbMap = eventNetworkToDbMap;
            this.eventService = eventService;

            eventConverterGenericType = typeof(IEventConverter<,>);
            eventServiceType = typeof(IEventService);
        }

        public async Task HandleAsync(WebhookModel webhookModel)
        {
            var dataPack = webhookEventParser.Parse(webhookModel);

            var eventNetworkType = dataPack.Key;
            var eventDbType = eventNetworkToDbMap.GetDbType(eventNetworkType);

            var eventConverterType = eventConverterGenericType.MakeGenericType(eventNetworkType, eventDbType);
            var eventConverter = container.Get(eventConverterType);
            var convertMethod = eventConverterType.GetMethod("Convert");
            var dbEvent = convertMethod.Invoke(eventConverter, new[] { dataPack.Value });

            var saveGenericMethod = eventServiceType.GetMethod("SaveAsync");
            var saveMethod = saveGenericMethod.MakeGenericMethod(eventDbType);
            await (Task)saveMethod.Invoke(eventService, new[] { dbEvent });
        }
    }
}