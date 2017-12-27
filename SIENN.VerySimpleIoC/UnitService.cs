using SIENN.BusinessInterfaces;
using SIENN.BusinessInterfaces.Contracts;
using SIENN.DbAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.VerySimpleIoC
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
            throw new NotImplementedException();
        }

        public UnitDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UnitDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(UnitDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UnitDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
