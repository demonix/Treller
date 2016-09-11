using System.Collections.Generic;
using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Factories;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.Repositories;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public class EventService : IEventService
    {
        private readonly IUpsourceEventFactory upsourceEventFactory;
        private readonly IUpsourceEventRepository upsourceEventRepository;

        public EventService(
            IUpsourceEventFactory upsourceEventFactory,
            IUpsourceEventRepository upsourceEventRepository
            )
        {
            this.upsourceEventFactory = upsourceEventFactory;
            this.upsourceEventRepository = upsourceEventRepository;
        }

        public Task SaveAsync(WebhookModel webhookModel)
        {
            var upsourceEvent = upsourceEventFactory.Create(webhookModel);
            return upsourceEventRepository.InsertAsync(upsourceEvent);
        }

        public Task<List<UpsourceEvent>> EnumerateAsync(long afterTimestamp, int count)
        {
            return upsourceEventRepository.EnumerateAsync(afterTimestamp, count);
        }
    }
}