using AutoMapper;
using Store.Domain.Contracts;
using Store.Domain.Entities.Products;
using Store.Shared.Dtos.Products;
using Strore.Services.Abstractions.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Products
{
    public class productService(IUnitOfWork _unitOfWork , IMapper _mapper) : IproductService
    {

        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            var product = await _unitOfWork.GetRepository<int, Product>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<ProductResponse>>(product);
            return result;
        }
        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.GetRepository<int, Product>().GetAsync(id);
            var result = _mapper.Map<ProductResponse>(product);
            return result;
        }
        public async Task<IEnumerable<BrandTypeResponse>> GetAllBrandsAsync()
        {
            var brand = await _unitOfWork.GetRepository<int, ProductBrand>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<BrandTypeResponse>>(brand);
            return result;
        }
        public async Task<IEnumerable<BrandTypeResponse>> GetAllTyepsAsync()
        {
            var type = await _unitOfWork.GetRepository<int, ProductType>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<BrandTypeResponse>>(type);
            return result;
        }
    }
}
