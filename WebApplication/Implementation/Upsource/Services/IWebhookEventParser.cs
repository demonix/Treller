using System;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public interface IWebhookEventParser
    {
        Type Parse(string dataType);
    }
}