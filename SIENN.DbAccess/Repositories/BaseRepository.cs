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
            _context = context;
        }

        public abstract void Update(TEntity entity);

        private SiennContext _context;
    }
}
