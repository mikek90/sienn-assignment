using Microsoft.EntityFrameworkCore;
using SIENN.BusinessInterfaces;
using SIENN.DbAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIENN.DbAccess.Repositories
{
    public class TypeRepository : BaseRepository<TypeDTO>, ITypeRepository
    {
        public TypeRepository(SiennContext context) : base(context)
        { }

        public TypeDTO GetDetailed(int id)
        {
            var result = SiennContext.Type
                .Include(p => p.Products)
                .FirstOrDefault(s => s.TypeId == id);

            return result;
        }

        public override void Update(TypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
