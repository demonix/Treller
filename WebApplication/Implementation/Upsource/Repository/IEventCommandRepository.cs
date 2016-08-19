using System.Threading.Tasks;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Repository
{
    public interface IEventCommandRepository
    {
        Task InsertAsync<TEvent>(TEvent @event);
    }
}