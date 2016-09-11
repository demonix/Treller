using System.Collections.Generic;
using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Repositories
{
    public interface IUpsourceEventRepository
    {
        Task InsertAsync(UpsourceEvent upsourceEvent);
        Task<List<UpsourceEvent>> EnumerateAsync(long afterTimestamp, int count);
    }
}