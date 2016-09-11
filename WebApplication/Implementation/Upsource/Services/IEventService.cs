using System.Collections.Generic;
using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public interface IEventService
    {
        Task SaveAsync(WebhookModel webhookModel);
        Task<List<UpsourceEvent>> EnumerateAsync(long afterTimestamp, int count);
    }
}