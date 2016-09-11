using System;
using System.Collections.Generic;
using System.Linq;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Reflection
{
    public class WebhookEventParser : IWebhookEventParser
    {
        private readonly Dictionary<string, Type> typeMap;

        public WebhookEventParser()
        {
            typeMap = Build();
        }

        public Type Parse(string dataType)
        {
            return typeMap[dataType];
        }

        private static Dictionary<string, Type> Build()
        {
            var eventBeanInterfaceType = typeof(IEventBean);

            var map =
                typeof(WebhookEventParser)
                .Assembly
                .GetTypes()
                .Where(p => p.IsClass && eventBeanInterfaceType.IsAssignableFrom(p))
                .ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);

            return map;
        }
    }
}