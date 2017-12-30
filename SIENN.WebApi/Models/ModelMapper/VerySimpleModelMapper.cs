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

        public static ProductModel Map(ProductDTO source)
        {
            if (source == null)
            {
                return null;
            }

            return new ProductModel
            {
                Id = source.Id,
                Code = source.Code,
                Description = source.Description,
                DeliveryDate = source.DeliveryDate,
                IsAvailable = source.IsAvailable,
                Price = source.Price,
                TypeId = source.TypeId,
                UnitId = source.UnitId,
                CategoryIds = source.ProductCategories?.Select(s => s.CategoryId).ToArray()
            };
        }

        public static ProductDTO Map(ProductModel source)
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

        public static CategoryModel Map(CategoryDTO source)
        {
            if (source == null)
            {
                return null;
            }

            return new CategoryModel
            {
                Id = source.Id,
                Code = source.Code,
                Description = source.Description
            };
        }

        public static CategoryDTO Map(CategoryModel source)
        {
            if (source == null)
            {
                return null;
            }

            return new CategoryDTO
            {
                Id = source.Id,
                Code = source.Code,
                Description = source.Description
            };
        }

        public static TypeModel Map(TypeDTO source)
        {
            if (source == null)
            {
                return null;
            }

            return new TypeModel
            {
                Id = source.Id,
                Code = source.Code,
                Description = source.Description
            };
        }

        public static TypeDTO Map(TypeModel source)
        {
            if (source == null)
            {
                return null;
            }

            return new TypeDTO
            {
                Id = source.Id,
                Code = source.Code,
                Description = source.Description
            };
        }

        public static UnitModel Map(UnitDTO source)
        {
            if (source == null)
            {
                return null;
            }

            return new UnitModel
            {
                Id = source.Id,
                Code = source.Code,
                Description = source.Description
            };
        }

        public static UnitDTO Map(UnitModel source)
        {
            if (source == null)
            {
                return null;
            }

            return new UnitDTO
            {
                Id = source.Id,
                Code = source.Code,
                Description = source.Description
            };
        }
    }
}
