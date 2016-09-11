using System;
using System.Collections.Generic;
using System.Linq;

namespace SKBKontur.Treller.WebApplication.Implementation.Mongo.Builders
{
    public class ChangeSetBuilder : IChangeSetBuilder
    {
        public ChangeSet<TEntity> Build<TEntity>(List<TEntity> origin, List<TEntity> actual) where TEntity : class, IDbEntity
        {
            var originEntities = origin.ToDictionary(e => e.Id);
            var actualEntities = actual.ToDictionary(e => e.Id);

            var updatedIds = new HashSet<Guid>(originEntities.Keys.Intersect(actualEntities.Keys));
            var createdIds = actualEntities.Keys.Where(x => !updatedIds.Contains(x));
            var deletedIds = originEntities.Keys.Where(x => !updatedIds.Contains(x));

            var updated = updatedIds.Select(x => actualEntities[x]).ToList();
            var deleted = deletedIds.Select(x => originEntities[x]).ToList();
            var created = createdIds.Select(x => actualEntities[x]).ToList();

            return new ChangeSet<TEntity>
            {
                Created = created,
                Updated = updated,
                Deleted = deleted
            };
        }
    }
}