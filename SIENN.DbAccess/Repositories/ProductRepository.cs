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

        public override void Add(ProductDTO entity)
        {
            //base.Add(entity);

            if (entity.ProductId.HasValue)
            {
                entity.ProductId = null;
            }

            SiennContext.Product.Add(entity);
            SiennContext.SaveChanges();
        }

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
            using (var dbContextTransaction = SiennContext.Database.BeginTransaction())
            {
                try
                {
                    if (!entity.ProductId.HasValue)
                    {
                        throw new Exception($"Entity does not contain Id.");
                    }

                    var dto = SiennContext.Product.FirstOrDefault(x => x.ProductId == entity.ProductId);
                    if (dto == null)
                    {
                        throw new Exception($"Product with ID = {entity.ProductId} not found.");
                    }

                    SiennContext.ProductCategory.RemoveRange(SiennContext.ProductCategory.Where(x => x.ProductId == entity.ProductId));
                    SiennContext.SaveChanges();

                    dto.Code = entity.Code;
                    dto.Description = entity.Description;
                    dto.DeliveryDate = entity.DeliveryDate;
                    dto.IsAvailable = entity.IsAvailable ?? dto.IsAvailable;
                    dto.Price = entity.Price ?? dto.Price;
                    dto.TypeId = entity.TypeId;
                    dto.UnitId = entity.UnitId;
                    dto.ProductCategories = entity.ProductCategories;

                    SiennContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
