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
            // DTO to model
            CreateMap<CategoryDTO, CategoryModel>();
            CreateMap<UnitDTO, UnitModel>();
            CreateMap<TypeDTO, TypeModel>();

            // Model to DTO
            CreateMap<CategoryModel, CategoryDTO>();
            CreateMap<UnitModel, UnitDTO>();
            CreateMap<TypeModel, TypeDTO>();
        }
    }
}
