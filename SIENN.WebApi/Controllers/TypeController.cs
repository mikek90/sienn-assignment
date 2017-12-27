using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIENN.BusinessInterfaces.Contracts;

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
            return Ok(dto);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_typeService.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _typeService.Remove(id);
            return Ok();
        }
    }
}