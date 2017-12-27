using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.BusinessInterfaces.Contracts
{
    public interface IBaseCrudService<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();

        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
