using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.BusinessInterfaces.Contracts
{
    public interface IBaseCrudService<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
