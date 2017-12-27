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

        public override void Add(TypeDTO entity)
        {
            if (entity.TypeId.HasValue)
            {
                entity.TypeId = null;
            }

            SiennContext.Type.Add(entity);
            SiennContext.SaveChanges();
        }

        public override TypeDTO GetDetailed(int id)
        {
            var result = SiennContext.Type
                .Include(p => p.Products)
                .FirstOrDefault(s => s.TypeId == id);

            return result;
        }

        public override void Update(TypeDTO entity)
        {
            var dto = SiennContext.Type.FirstOrDefault(x => x.TypeId == entity.TypeId);
            if (dto == null)
            {
                throw new Exception($"Type with ID = {entity.TypeId} not found.");
            }

            dto.Code = entity.Code;
            dto.Description = entity.Description;

            SiennContext.SaveChanges();
        }
    }
}
