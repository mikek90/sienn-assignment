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
    [Route("api/Unit")]
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService UnitService)
        {
            _unitService = UnitService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dto = _unitService.Get(id);
            return Ok(dto);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_unitService.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitService.Remove(id);
            return Ok();
        }
    }
}