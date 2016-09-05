using System;
using System.Collections.Generic;
using System.Linq;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public class WebhookEventParser : IWebhookEventParser
    {
        private readonly Dictionary<string, Type> typeMap;

        public WebhookEventParser()
        {
            var eventBeanInterfaceType = typeof(IEventBean);
            typeMap = typeof(WebhookEventParser)
                .Assembly
                .GetTypes()
                .Where(p => p.IsClass && eventBeanInterfaceType.IsAssignableFrom(p))
                .ToDictionary(
                    x => x.Name,
                    x => x,
                    StringComparer.OrdinalIgnoreCase
                );
        }

        public Type Parse(string dataType)
        {
            return typeMap[dataType];
        }
    }
}