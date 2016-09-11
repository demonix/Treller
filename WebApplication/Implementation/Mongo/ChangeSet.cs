using System.Collections.Generic;

namespace SKBKontur.Treller.WebApplication.Implementation.Mongo
{
    public class ChangeSet<TEntity>
    {
        public List<TEntity> Created { get; set; }
        public List<TEntity> Updated { get; set; }
        public List<TEntity> Deleted { get; set; }
    }
}