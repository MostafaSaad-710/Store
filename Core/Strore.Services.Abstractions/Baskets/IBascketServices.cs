using Store.Shared.Dtos.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strore.Services.Abstractions.Baskets
{
    public interface IBascketServices
    {
        Task<BasketDto?> GetBasketAsync(string id);
        Task<BasketDto?> CrateBasketAsync(BasketDto dto , TimeSpan during);
        Task<bool> DeleteBasketAsync(string id);
    }
}
