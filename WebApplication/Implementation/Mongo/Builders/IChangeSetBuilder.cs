using System.Collections.Generic;

namespace SKBKontur.Treller.WebApplication.Implementation.Mongo.Builders
{
    public interface IChangeSetBuilder
    {
        ChangeSet<TEntity> Build<TEntity>(List<TEntity> origin, List<TEntity> actual) where TEntity : class, IDbEntity;
    }
}