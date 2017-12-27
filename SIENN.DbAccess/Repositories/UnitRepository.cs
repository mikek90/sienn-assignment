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

        public override UnitDTO GetDetailed(int id)
        {
            var result = SiennContext.Unit
                .Include(p => p.Products)
                .FirstOrDefault(s => s.UnitId == id);

            return result;
        }

        public override void Update(UnitDTO entity)
        {
            var dto = SiennContext.Unit.FirstOrDefault(x => x.UnitId == entity.UnitId);
            if (dto == null)
            {
                throw new Exception($"Unit with ID = {entity.UnitId} not found.");
            }

            dto.Code = entity.Code;
            dto.Description = entity.Description;

            SiennContext.SaveChanges();
        }
    }
}
