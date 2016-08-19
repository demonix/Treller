using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Converters
{
    public class UpsourceUserConverter : IUpsourceUserConverter
    {
        public UpsourceUser Convert(UserIdBean userIdBean)
        {
            return new UpsourceUser
            {
                Id = userIdBean.Id,
                Email = userIdBean.Email,
                Name = userIdBean.Name
            };
        }
    }
}