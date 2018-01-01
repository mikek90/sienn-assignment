using SIENN.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIENN.WebApi.Models.ModelMapper
{
    // TODO: Add AutoMapper or implement more generic version with IoC in future
    public static class VerySimpleModelMapper
    {
        public static SpecialProductModel MapSpecial(ProductDTO source)
        {
            string template = "({0}) {1}";

            if (source == null)
            {
                return null;
            }

            return new SpecialProductModel
            {
                CategoriesCount = source.ProductCategories.Count(),
                DeliveryDate = source.DeliveryDate.HasValue ? source.DeliveryDate.Value.ToString("dd.MM.yyyy") : string.Empty,
                IsAvailable = source.IsAvailable.Value ? "Dostępny" : "Niedostępny",
                Price = $"{source.Price.Value:n2} zł",
                ProductDescription = string.Format(template, source.Code, source.Description),
                Type = source.Type == null ? string.Empty : string.Format(template, source.Type.Code, source.Type.Description),
                Unit = source.Unit == null ? string.Empty : string.Format(template, source.Unit.Code, source.Unit.Description)
            };
        }

        public static ProductDTO Map(ProductEditModel source)
        {
            if (source == null)
            {
                return null;
            }

            var result = new ProductDTO
            {
                Id = source.Id,
                Code = source.Code,
                Description = source.Description,
                DeliveryDate = source.DeliveryDate,
                IsAvailable = source.IsAvailable,
                Price = source.Price,
                TypeId = source.TypeId,
                UnitId = source.UnitId,
                ProductCategories = source.CategoryIds.Select(s => new ProductCategoryDTO { CategoryId = s, ProductId = source.Id }).ToList()
            };

            return result;
        }

        public static ProductSearchCriteria Map(ProductSearchRequestModel source)
        {
            return new ProductSearchCriteria
            {
                ItemsCount = source.ItemsCount,
                PageNumber = source.PageNumber,
                CategoryIds = source.CategoryIds,
                TypeIds = source.TypeIds,
                UnitIds = source.UnitIds
            };
        }
    }
}
