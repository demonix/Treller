using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public interface IEventHandler
    {
        Task HandleAsync(WebhookModel webhookModel);
    }
}