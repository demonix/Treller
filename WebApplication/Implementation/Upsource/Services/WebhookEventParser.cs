using System;
using System.Collections.Generic;
using System.Linq;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public class WebhookEventParser : IWebhookEventParser
    {
        private readonly Dictionary<string, Type> typeMap;

        public WebhookEventParser()
        {
            var type = typeof (IEvent);
            typeMap = typeof(WebhookEventParser).Assembly.GetTypes().Where(p => type.IsAssignableFrom(p) && p.IsClass).ToDictionary(x => x.Name.ToLower());
        }

        public KeyValuePair<Type, object> Parse(WebhookModel webhookModel)
        {
            var dataType = typeMap[webhookModel.DataType.ToLower()];
            return new KeyValuePair<Type, object>(dataType, webhookModel.Data);
        }
    }
}