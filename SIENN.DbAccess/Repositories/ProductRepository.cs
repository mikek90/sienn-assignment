﻿using Microsoft.EntityFrameworkCore;
using SIENN.BusinessInterfaces;
using SIENN.DbAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIENN.DbAccess.Repositories
{
    public class ProductRepository : BaseRepository<ProductDTO>, IProductRepository
    {
        public ProductRepository(SiennContext context) : base(context)
        {
            _context = context;
        }

        public override ProductDTO Get(int id)
        {
            var result = _context.Product
                .Include(u => u.Unit)
                .Include(t => t.Type)
                .Include(x => x.ProductCategories)
                .SingleOrDefault(s => s.ProductId == id);

            return result;
        }

        public override void Update(ProductDTO entity)
        {
            throw new NotImplementedException();
        }

        private SiennContext _context;
    }
}
