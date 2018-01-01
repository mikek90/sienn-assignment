using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIENN.BusinessInterfaces;
using SIENN.BusinessInterfaces.Contracts;
using SIENN.WebApi.Models;
using SIENN.WebApi.Models.ModelMapper;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Type")]
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;
        private readonly IMapper _mapper;

        public TypeController(ITypeService TypeService, IMapper mapper)
        {
            _typeService = TypeService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dto = _typeService.Get(id);
            if (dto == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<TypeDTO, TypeModel>(dto));
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var colDto = _typeService.GetAll();
            return Ok(colDto.Select(s => _mapper.Map<TypeDTO, TypeModel>(s)));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]TypeModel model)
        {
            if (!ModelState.IsValid || model == null || model.Id.HasValue)
            {
                return BadRequest();
            }
            _typeService.Add(_mapper.Map<TypeModel, TypeDTO>(model));
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody]TypeModel model)
        {
            if (!ModelState.IsValid || model == null || !model.Id.HasValue)
            {
                return BadRequest();
            }
            _typeService.Update(_mapper.Map<TypeModel, TypeDTO>(model));
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _typeService.Remove(id);
            return Ok();
        }
    }
}