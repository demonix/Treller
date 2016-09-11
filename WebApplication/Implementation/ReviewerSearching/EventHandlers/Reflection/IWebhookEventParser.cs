using System;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Reflection
{
    public interface IWebhookEventParser
    {
        Type Parse(string dataType);
    }
}