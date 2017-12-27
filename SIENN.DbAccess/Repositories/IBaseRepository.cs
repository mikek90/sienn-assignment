using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.DbAccess.Repositories
{
    public interface IBaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetDetailed(int id);
        void Update(TEntity entity);
    }
}
