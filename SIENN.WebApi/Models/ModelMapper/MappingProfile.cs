using AutoMapper;
using SIENN.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIENN.WebApi.Models.ModelMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            string template = "({0}) {1}";

            // DTO to model
            CreateMap<ProductDTO, ProductModel>();
            CreateMap<ProductDTO, ProductSpecialModel>()
                .ForMember(pm => pm.CategoriesCount, opt => opt.MapFrom(p => p.ProductCategories.Count()))
                .ForMember(pm => pm.DeliveryDate, opt => opt.MapFrom(p => p.DeliveryDate.HasValue ? p.DeliveryDate.Value.ToString("dd.MM.yyyy") : string.Empty))
                .ForMember(pm => pm.IsAvailable, opt => opt.MapFrom(p => p.IsAvailable.Value ? "Dostępny" : "Niedostępny"))
                .ForMember(pm => pm.Price, opt => opt.MapFrom(p => $"{p.Price.Value:n2} zł"))
                .ForMember(pm => pm.ProductDescription, opt => opt.MapFrom(p => string.Format(template, p.Code, p.Description)))
                .ForMember(pm => pm.Type, opt => opt.MapFrom(p => p.Type == null ? string.Empty : string.Format(template, p.Type.Code, p.Type.Description)))
                .ForMember(pm => pm.Unit, opt => opt.MapFrom(p => p.Unit == null ? string.Empty : string.Format(template, p.Unit.Code, p.Unit.Description)));

            CreateMap<CategoryDTO, CategoryModel>();
            CreateMap<UnitDTO, UnitModel>();
            CreateMap<TypeDTO, TypeModel>();

            // Model to DTO
            CreateMap<ProductModel, ProductDTO>();
            CreateMap<ProductEditModel, ProductDTO>()
                .ForMember(p => p.ProductCategories, opt => opt.MapFrom(pem => pem.CategoryIds.Select(s => new ProductCategoryDTO { CategoryId = s, ProductId = pem.Id }).ToList()));
            CreateMap<ProductSearchRequestModel, ProductSearchCriteria>();

            CreateMap<CategoryModel, CategoryDTO>();
            CreateMap<UnitModel, UnitDTO>();
            CreateMap<TypeModel, TypeDTO>();
        }
    }
}
