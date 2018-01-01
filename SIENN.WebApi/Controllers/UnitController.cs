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
    [Route("api/Unit")]
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;
        private readonly IMapper _mapper;

        public UnitController(IUnitService UnitService, IMapper mapper)
        {
            _unitService = UnitService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dto = _unitService.Get(id);
            if (dto == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<UnitDTO, UnitModel>(dto));
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var colDto = _unitService.GetAll();
            return Ok(colDto.Select(s => _mapper.Map<UnitDTO, UnitModel>(s)));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]UnitModel model)
        {
            if (!ModelState.IsValid || model == null || model.Id.HasValue)
            {
                return BadRequest();
            }
            _unitService.Add(_mapper.Map<UnitModel, UnitDTO>(model));
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody]UnitModel model)
        {
            if (!ModelState.IsValid || model == null || !model.Id.HasValue)
            {
                return BadRequest();
            }
            _unitService.Update(_mapper.Map<UnitModel, UnitDTO>(model));
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitService.Remove(id);
            return Ok();
        }
    }
}