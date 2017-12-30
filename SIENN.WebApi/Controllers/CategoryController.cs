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
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService CategoryService, IMapper mapper)
        {
            _categoryService = CategoryService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dto = _categoryService.Get(id);
            if (dto == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<CategoryDTO, CategoryModel>(dto));
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var colDto = _categoryService.GetAll();
            return Ok(colDto.Select(s => _mapper.Map<CategoryDTO, CategoryModel>(s)));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]CategoryModel model)
        {
            if (ModelState.ErrorCount > 0 || model == null || model.Id.HasValue)
            {
                return BadRequest();
            }
            _categoryService.Add(VerySimpleModelMapper.Map(model));
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody]CategoryModel model)
        {
            if (ModelState.ErrorCount > 0 || model == null || !model.Id.HasValue)
            {
                return BadRequest();
            }
            _categoryService.Update(VerySimpleModelMapper.Map(model));
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Remove(id);
            return Ok();
        }
    }
}