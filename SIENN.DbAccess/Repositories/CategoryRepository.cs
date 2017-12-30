using Microsoft.EntityFrameworkCore;
using SIENN.BusinessInterfaces;
using SIENN.DbAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIENN.DbAccess.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryDTO>, ICategoryRepository
    {
        public CategoryRepository(SiennContext context) : base(context)
        { }

        public override void Add(CategoryDTO entity)
        {
            if (entity.Id.HasValue)
            {
                entity.Id = null;
            }

            SiennContext.Category.Add(entity);
            SiennContext.SaveChanges();
        }

        public override CategoryDTO GetDetailed(int id)
        {
            var result = SiennContext.Category
                .Include(c => c.ProductCategories)
                .FirstOrDefault(x => x.Id == id);

            return result;
        }

        public override void Update(CategoryDTO entity)
        {
            var dto = SiennContext.Category.FirstOrDefault(x => x.Id == entity.Id);
            if (dto == null)
            {
                throw new Exception($"Category with ID = {entity.Id} not found.");
            }

            dto.Code = entity.Code;
            dto.Description = entity.Description;

            SiennContext.SaveChanges();
        }
    }
}
