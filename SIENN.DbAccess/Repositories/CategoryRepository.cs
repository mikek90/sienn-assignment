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

        public override CategoryDTO GetDetailed(int id)
        {
            var result = SiennContext.Category
                .Include(c => c.ProductCategories)
                .FirstOrDefault(x => x.CategoryId == id);

            return result;
        }

        public override void Update(CategoryDTO entity)
        {
            var dto = SiennContext.Category.FirstOrDefault(x => x.CategoryId == entity.CategoryId);
            if (dto == null)
            {
                throw new Exception($"Category with ID = {entity.CategoryId} not found.");
            }

            dto.Code = entity.Code;
            dto.Description = entity.Description;

            SiennContext.SaveChanges();
        }
    }
}
