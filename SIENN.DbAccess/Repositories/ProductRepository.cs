using Microsoft.EntityFrameworkCore;
using SIENN.BusinessInterfaces;
using SIENN.DbAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.DbAccess.Repositories
{
    public class ProductRepository : GenericRepository<ProductDTO>, IProductRepository
    {
        public ProductRepository(SiennContext context) : base(context)
        { }
    }
}
