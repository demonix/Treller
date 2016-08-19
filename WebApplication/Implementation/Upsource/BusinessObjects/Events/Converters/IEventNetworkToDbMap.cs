using System;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public interface IEventNetworkToDbMap
    {
        Type GetDbType(Type networkType);
    }
}