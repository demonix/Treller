using System;
using System.Collections.Generic;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public interface IWebhookEventParser
    {
        KeyValuePair<Type, object> Parse(WebhookModel webhookModel);
    }
}