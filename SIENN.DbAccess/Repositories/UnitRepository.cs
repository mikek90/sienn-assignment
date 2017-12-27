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

        public UnitDTO GetDetailed(int id)
        {
            var result = SiennContext.Unit
                .Include(p => p.Products)
                .FirstOrDefault(s => s.UnitId == id);

            return result;
        }

        public override void Update(UnitDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
