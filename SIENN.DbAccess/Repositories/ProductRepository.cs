using Microsoft.EntityFrameworkCore;
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
        { }

        public override ProductDTO GetDetailed(int id)
        {
            var result = SiennContext.Product
                .Include(u => u.Unit)
                .Include(t => t.Type)
                .Include(x => x.ProductCategories)
                .FirstOrDefault(s => s.ProductId == id);

            return result;
        }

        public override void Update(ProductDTO entity)
        {
            var dto = SiennContext.Product.FirstOrDefault(x => x.ProductId == entity.ProductId);
            if (dto == null)
            {
                throw new Exception($"Product with ID = {entity.ProductId} not found.");
            }

            dto.Code = entity.Code;
            dto.Description = entity.Description;
            dto.DeliveryDate = entity.DeliveryDate;
            dto.IsAvailable = entity.IsAvailable;
            dto.Price = entity.Price;
            dto.TypeId = entity.TypeId;
            dto.UnitId = entity.UnitId;
            dto.ProductCategories = entity.ProductCategories;

            SiennContext.SaveChanges();
        }
    }
}
