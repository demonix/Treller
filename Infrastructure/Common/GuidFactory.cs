using System;

namespace SKBKontur.Infrastructure.Common
{
    public class GuidFactory : IGuidFactory
    {
        public Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}