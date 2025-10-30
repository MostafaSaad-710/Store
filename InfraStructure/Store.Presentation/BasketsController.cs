using Microsoft.AspNetCore.Mvc;
using Store.Shared.Dtos.Baskets;
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
    public class BasketsController(IServiceManager _serviceManager) : ControllerBase
    {

        [HttpGet] //Get: baseUrl/api/baskets?id
        public async Task<ActionResult> GetBasketById(string id)
        {
            var result = await _serviceManager.BascketServices.GetBasketAsync(id);

            return Ok(result);
        }


        [HttpPost]//Get: baseUrl/api/baskets
        public async Task<ActionResult> CreateOrUpdateBasket(BasketDto dto)
        {
            var result = await _serviceManager.BascketServices.CrateBasketAsync(dto , TimeSpan.FromDays(1));

            return Ok(result);
        }

        [HttpDelete]//Get: baseUrl/api/baskets?id
        public async Task<ActionResult> DeleteBasket(string id)
        {
            var result = await _serviceManager.BascketServices.DeleteBasketAsync(id);

            return NoContent(); //204
        }

    }
}
