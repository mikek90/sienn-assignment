using SIENN.BusinessInterfaces;
using SIENN.BusinessInterfaces.Contracts;
using SIENN.DbAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public void Add(UnitDTO entity)
        {
            _unitRepository.Add(entity);
        }

        public UnitDTO Get(int id)
        {
            return _unitRepository.Get(id);
        }

        public IEnumerable<UnitDTO> GetAll()
        {
            return _unitRepository.GetAll();
        }

        public void Remove(int id)
        {
            var entity = _unitRepository.Get(id);
            _unitRepository.Remove(entity);
        }

        public void Update(UnitDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
