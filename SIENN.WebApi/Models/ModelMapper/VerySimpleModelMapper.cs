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
        public static BaseModel Map(ProductDTO source)
        {
            return new BaseModel
            {
                Id = source.ProductId,
                Code = source.Code,
                Description = source.Description
            };
        }

        public static CategoryModel Map(CategoryDTO source)
        {
            return new CategoryModel
            {
                Id = source.CategoryId,
                Code = source.Code,
                Description = source.Description
            };
        }

        public static CategoryDTO Map(CategoryModel source)
        {
            return new CategoryDTO
            {
                CategoryId = source.Id,
                Code = source.Code,
                Description = source.Description
            };
        }

        public static TypeModel Map(TypeDTO source)
        {
            return new TypeModel
            {
                Id = source.TypeId,
                Code = source.Code,
                Description = source.Description
            };
        }

        public static TypeDTO Map(TypeModel source)
        {
            return new TypeDTO
            {
                TypeId = source.Id,
                Code = source.Code,
                Description = source.Description
            };
        }

        public static UnitModel Map(UnitDTO source)
        {
            return new UnitModel
            {
                Id = source.UnitId,
                Code = source.Code,
                Description = source.Description
            };
        }

        public static UnitDTO Map(UnitModel source)
        {
            return new UnitDTO
            {
                UnitId = source.Id,
                Code = source.Code,
                Description = source.Description
            };
        }
    }
}
