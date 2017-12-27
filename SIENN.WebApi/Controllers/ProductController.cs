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
            var productDto = _productService.Get(id);
            return Ok(productDto);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Remove(id);
            return Ok();
        }
    }
}