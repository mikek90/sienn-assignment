using SIENN.BusinessInterfaces;
using SIENN.BusinessInterfaces.Contracts;
using SIENN.DbAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.VerySimpleIoC
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public void Add(TypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public TypeDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TypeDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(TypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
