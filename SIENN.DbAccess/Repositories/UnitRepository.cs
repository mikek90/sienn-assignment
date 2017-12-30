using Microsoft.EntityFrameworkCore;
using SIENN.BusinessInterfaces;
using SIENN.DbAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIENN.DbAccess.Repositories
{
    public class UnitRepository : BaseRepository<UnitDTO>, IUnitRepository
    {
        public UnitRepository(SiennContext context) : base(context)
        { }

        public override void Add(UnitDTO entity)
        {
            if (entity.Id.HasValue)
            {
                entity.Id = null;
            }

            SiennContext.Unit.Add(entity);
            SiennContext.SaveChanges();
        }

        public override UnitDTO GetDetailed(int id)
        {
            var result = SiennContext.Unit
                .Include(p => p.Products)
                .FirstOrDefault(s => s.Id == id);

            return result;
        }

        public override void Update(UnitDTO entity)
        {
            var dto = SiennContext.Unit.FirstOrDefault(x => x.Id == entity.Id);
            if (dto == null)
            {
                throw new Exception($"Unit with ID = {entity.Id} not found.");
            }

            dto.Code = entity.Code;
            dto.Description = entity.Description;

            SiennContext.SaveChanges();
        }
    }
}
