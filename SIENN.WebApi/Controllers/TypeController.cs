using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public TypeController(ITypeService TypeService)
        {
            _typeService = TypeService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dto = _typeService.Get(id);
            if (dto == null)
            {
                return BadRequest();
            }

            return Ok(VerySimpleModelMapper.Map(dto));
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var colDto = _typeService.GetAll();
            return Ok(colDto.Select(s => VerySimpleModelMapper.Map(s)));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]TypeModel model)
        {
            if (ModelState.ErrorCount > 0 || model == null || model.Id.HasValue)
            {
                return BadRequest();
            }
            _typeService.Add(VerySimpleModelMapper.Map(model));
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody]TypeModel model)
        {
            if (ModelState.ErrorCount > 0 || model == null || !model.Id.HasValue)
            {
                return BadRequest();
            }
            _typeService.Update(VerySimpleModelMapper.Map(model));
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