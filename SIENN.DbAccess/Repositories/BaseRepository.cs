using SIENN.DbAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.DbAccess.Repositories
{
    public abstract class BaseRepository<TEntity> : GenericRepository<TEntity>, IBaseRepository<TEntity> where TEntity : class
    {
        public BaseRepository(SiennContext context) : base(context)
        {
            SiennContext = context;
        }

        public override void Remove(TEntity entity)
        {
            SiennContext.Remove(entity);
            SiennContext.SaveChanges();
        }

        public abstract void Update(TEntity entity);

        protected SiennContext SiennContext;
    }
}
