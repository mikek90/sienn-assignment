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

        public IEnumerable<ProductDTO> Search(ProductSearchCriteria criteria)
        {
            int start = criteria.PageNumber > 0 ? criteria.PageNumber - 1 : criteria.PageNumber;
            start = start * criteria.ItemsCount;

            var query = SiennContext.Product.Include(x => x.ProductCategories).Where(x => x.ProductId > 0);

            if (criteria.IsAvailable.HasValue)
            {
                query = query.Where(x => x.IsAvailable == criteria.IsAvailable.Value);
            }
            if (criteria.TypeIds != null && criteria.TypeIds.Length > 0 )
            {
                query = query.Where(x => criteria.TypeIds.Contains(x.TypeId.Value));
            }
            if (criteria.UnitIds != null && criteria.UnitIds.Length > 0)
            {
                query = query.Where(x => criteria.UnitIds.Contains(x.UnitId.Value));
            }
            if (criteria.CategoryIds != null && criteria.CategoryIds.Length > 0)
            {
                query = query.Where(x => criteria.CategoryIds.Intersect(x.ProductCategories.Select(s => s.CategoryId).ToArray()).Any());
            }

            return query.Skip(start).Take(criteria.ItemsCount).ToList();
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
