using SIENN.BusinessInterfaces;
using SIENN.DbAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.DbAccess.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryDTO>, ICategoryRepository
    {
        public CategoryRepository(SiennContext context) : base(context)
        { }
    }
}
