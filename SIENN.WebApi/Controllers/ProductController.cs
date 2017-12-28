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
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dto = _productService.GetDetailed(id); // Get
            if (dto == null)
            {
                return BadRequest();
            }

            return Ok(VerySimpleModelMapper.Map(dto));
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var colDto = _productService.GetAll();
            return Ok(colDto.Select(s => VerySimpleModelMapper.Map(s)));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]ProductModel model)
        {
            if (ModelState.ErrorCount > 0 || model == null)
            {
                return BadRequest();
            }
            _productService.Add(VerySimpleModelMapper.Map(model));
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody]ProductModel model)
        {
            if (ModelState.ErrorCount > 0 || model == null || !model.Id.HasValue)
            {
                return BadRequest();
            }
            _productService.Update(VerySimpleModelMapper.Map(model));
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Remove(id);
            return Ok();
        }
    }
}