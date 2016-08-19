using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.Repository;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services
{
    public interface IEventService
    {
        Task SaveAsync<TEvent>(TEvent @event) where TEvent : class, IEvent;
    }

    public class EventService : IEventService
    {
        private readonly IEventCommandRepository eventCommandRepository;

        public EventService(
            IEventCommandRepository eventCommandRepository)
        {
            this.eventCommandRepository = eventCommandRepository;
        }

        public async Task SaveAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            await eventCommandRepository.InsertAsync(@event).ConfigureAwait(false);
        }
    }
}