using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Converters
{
    public interface IUpsourceUserConverter
    {
        UpsourceUser Convert(UserIdBean userIdBean);
    }
}