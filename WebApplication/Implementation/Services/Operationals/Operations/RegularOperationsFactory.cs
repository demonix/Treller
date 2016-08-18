using System;
using SKBKontur.Treller.WebApplication.Implementation.Infrastructure.Storages;

namespace SKBKontur.Treller.WebApplication.Implementation.Services.Operationals.Operations
{
    public class RegularOperationsFactory : IRegularOperationsFactory
    {
        private readonly ICachedFileStorage cachedFileStorage;

        public RegularOperationsFactory(
            ICachedFileStorage cachedFileStorage
        )
        {
            this.cachedFileStorage = cachedFileStorage;
        }

        public IRegularOperation Create(string name, Action action)
        {
            return new SimpleOperation(name, action);
        }

        public IRegularOperation Create(string name, Func<long, long> enumeration, Func<long> defaultTimetampFunc)
        {
            return new EnumerationOperation(cachedFileStorage, name, enumeration, defaultTimetampFunc);
        }
    }
}