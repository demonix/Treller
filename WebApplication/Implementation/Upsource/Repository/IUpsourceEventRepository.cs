using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Repository
{
    public interface IUpsourceEventRepository
    {
        Task InsertAsync(UpsourceEvent upsourceEvent);
    }
}