using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services;
using Store.Shared;
using Store.Shared.Dtos.Products;
using Store.Shared.ErrorModels;
using Strore.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager _serviceManager) : ControllerBase
    {

        //Priceasc
        //Pricedesc
        //nameasc


        [HttpGet]// Get//: baseUrl/api/Products
        [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(PaginationResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError , Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest , Type = typeof(ErrorDetails))]
        public async Task<ActionResult<PaginationResponse<ProductResponse>>> GetAllProducts([FromQuery] ProductQueryParameters parameters)
        {
            var result = await _serviceManager.productService.GetAllProductsAsync(parameters);
            return Ok(result); //200
        }



        [HttpGet("{id}")]// Get//: baseUrl/api/Products/id
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<ProductResponse>> GetProductById(int? id)
        {
            if(id is null) return BadRequest();

            var result = await _serviceManager.productService.GetProductByIdAsync(id.Value);

            //if (result is null) return NotFound(); // 400

            return Ok(result); //200
        }



        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandTypeResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [HttpGet("brands")]// Get//: baseUrl/api/Products/brands
        public async Task<ActionResult<BrandTypeResponse>> GetAllBrands()
        {
            var result = await _serviceManager.productService.GetAllBrandsAsync();
            if (result is null) return BadRequest(); // 400
            return Ok(result); //200
        }




        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandTypeResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [HttpGet("types")]// Get//: baseUrl/api/Products/brands
        public async Task<ActionResult<BrandTypeResponse>> GetAllTypes()
        {
            var result = await _serviceManager.productService.GetAllTyepsAsync();
            if (result is null) return BadRequest(); // 400
            return Ok(result); //200
        }
    }
}
