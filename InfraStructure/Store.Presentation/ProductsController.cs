using Microsoft.AspNetCore.Mvc;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(ServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet]// Get//: baseUrl/api/Products
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _serviceManager.productService.GetAllProductsAsync();
            if (result is null) return BadRequest(); // 400
            return Ok(result); //200
        }
    }
}
