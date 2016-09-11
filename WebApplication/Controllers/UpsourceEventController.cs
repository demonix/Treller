using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.Services.ErrorService;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.Services;

namespace SKBKontur.Treller.WebApplication.Controllers
{
    public class UpsourceEventController : ExceptionHandledController
    {
        private readonly IEventService eventService;

        public UpsourceEventController(
            IErrorService errorService,
            IEventService eventService)
            : base(errorService)
        {
            this.eventService = eventService;
        }

        public async Task Handle(WebhookModel webhookModel)
        {
            await eventService.SaveAsync(webhookModel).ConfigureAwait(true);
        }
    }
}