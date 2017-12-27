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
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dto = _categoryService.Get(id);
            return Ok(dto);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]CategoryModel model)
        {
            if (model.Id.HasValue)
            {
                return BadRequest("Input data should not contain Id.");
            }
            _categoryService.Add(VerySimpleModelMapper.Map(model));
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody]CategoryModel model)
        {
            if (!model.Id.HasValue)
            {
                return BadRequest("Input data should contain Id.");
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