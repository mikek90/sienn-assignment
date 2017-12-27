using SIENN.BusinessInterfaces;
using SIENN.BusinessInterfaces.Contracts;
using SIENN.DbAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.Services
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
            _typeRepository.Add(entity);
        }

        public TypeDTO Get(int id)
        {
            return _typeRepository.Get(id);
        }

        public IEnumerable<TypeDTO> GetAll()
        {
            return _typeRepository.GetAll();
        }

        public void Remove(int id)
        {
            var entity = _typeRepository.GetDetailed(id);
            _typeRepository.Remove(entity);
        }

        public void Update(TypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
