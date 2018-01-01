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
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService ProductService, IMapper mapper)
        {
            _productService = ProductService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dto = _productService.Get(id);
            if (dto == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<ProductDTO, ProductModel>(dto));
        }

        [HttpGet("special{id}")]
        public IActionResult GetSpecial(int id)
        {
            var dto = _productService.GetDetailed(id); // Get
            if (dto == null)
            {
                return BadRequest();
            }

            return Ok(VerySimpleModelMapper.MapSpecial(dto));
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var colDto = _productService.GetAll();
            return Ok(colDto.Select(s => _mapper.Map<ProductDTO, ProductModel>(s)));
        }

        [HttpGet("available")]
        public IActionResult GetAvailable(ProductAvailableRequestModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return BadRequest();
            }

            var colDto = _productService.GetAvailable(model.PageNumber, model.ItemsCount);
            return Ok(colDto.Select(s => _mapper.Map<ProductDTO, ProductModel>(s)));
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody]ProductSearchRequestModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                var modelStateErrors = this.ModelState.Values.SelectMany(m => m.Errors);

                return BadRequest();
            }

            var colDto = _productService.Search(VerySimpleModelMapper.Map(model));
            return Ok(colDto.Select(s => _mapper.Map<ProductDTO, ProductModel>(s)));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]ProductEditModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return BadRequest();
            }
            _productService.Add(VerySimpleModelMapper.Map(model));
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody]ProductEditModel model)
        {
            if (!ModelState.IsValid || model == null || !model.Id.HasValue)
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