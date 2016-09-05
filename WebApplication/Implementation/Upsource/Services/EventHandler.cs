using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Factories;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.Repository;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public class EventHandler : IEventHandler
    {
        private readonly IUpsourceEventFactory upsourceEventFactory;
        private readonly IUpsourceEventRepository upsourceEventRepository;

        public EventHandler(
            IUpsourceEventFactory upsourceEventFactory,
            IUpsourceEventRepository upsourceEventRepository
            )
        {
            this.upsourceEventFactory = upsourceEventFactory;
            this.upsourceEventRepository = upsourceEventRepository;
        }

        public async Task HandleAsync(WebhookModel webhookModel)
        {
            var upsourceEvent = upsourceEventFactory.Create(webhookModel);
            await upsourceEventRepository.InsertAsync(upsourceEvent).ConfigureAwait(true);
        }
    }
}