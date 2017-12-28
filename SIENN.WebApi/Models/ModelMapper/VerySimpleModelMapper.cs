﻿using SIENN.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIENN.WebApi.Models.ModelMapper
{
    // TODO: Add AutoMapper or implement more generic version with IoC in future
    public static class VerySimpleModelMapper
    {
        public static ProductModel Map(ProductDTO source)
        {
            if (source == null)
            {
                return null;
            }

            return new ProductModel
            {
                Id = source.ProductId,
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
                ProductId = source.Id,
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

        public static CategoryModel Map(CategoryDTO source)
        {
            if (source == null)
            {
                return null;
            }

            return new CategoryModel
            {
                Id = source.CategoryId,
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
                CategoryId = source.Id,
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
                Id = source.TypeId,
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
                TypeId = source.Id,
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
                Id = source.UnitId,
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
                UnitId = source.Id,
                Code = source.Code,
                Description = source.Description
            };
        }
    }
}
