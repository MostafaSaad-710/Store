using Store.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strore.Services.Abstractions.Products
{
    public interface IproductService
    {
        Task<IEnumerable<ProductResponse>> GetAllProductsAsync(int? brandId, int? TypeId , string? sort , string? search);
        Task<ProductResponse> GetProductByIdAsync(int id);
        Task<IEnumerable<BrandTypeResponse>> GetAllBrandsAsync();
        Task<IEnumerable<BrandTypeResponse>> GetAllTyepsAsync();


    }
}
