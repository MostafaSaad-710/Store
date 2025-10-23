using Microsoft.AspNetCore.Mvc;
using Store.Services;
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
        [HttpGet]// Get//: baseUrl/api/Products
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _serviceManager.productService.GetAllProductsAsync();
            if (result is null) return BadRequest(); // 400
            return Ok(result); //200
        }
        [HttpGet("{id}")]// Get//: baseUrl/api/Products/id
        public async Task<IActionResult> GetProductById(int? id)
        {
            if(id is null) return BadRequest();

            var result = await _serviceManager.productService.GetProductByIdAsync(id.Value);

            if (result is null) return NotFound(); // 400

            return Ok(result); //200
        }

        [HttpGet("brands")]// Get//: baseUrl/api/Products/brands
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await _serviceManager.productService.GetAllBrandsAsync();
            if (result is null) return BadRequest(); // 400
            return Ok(result); //200
        }

        [HttpGet("types")]// Get//: baseUrl/api/Products/brands
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _serviceManager.productService.GetAllTyepsAsync();
            if (result is null) return BadRequest(); // 400
            return Ok(result); //200
        }
    }
}
