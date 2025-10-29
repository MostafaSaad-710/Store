using AutoMapper;
using Store.Domain.Contracts;
using Store.Domain.Entities.Products;
using Store.Services.Specifications;
using Store.Services.Specifications.Products;
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

        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync(ProductQueryParameters parameters)
        {

            //var spec = new BaseSpecifications<int, Product>(null);
            //spec.Includes.Add(p => p.Brand);
            //spec.Includes.Add(p => p.Type);

            var spec = new ProductsWithBrandAndTypeSpecifications(parameters);
            var product = await _unitOfWork.GetRepository<int, Product>().GetAllAsync(spec);
            var result = _mapper.Map<IEnumerable<ProductResponse>>(product);
            return result;
        }
        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            var spec = new ProductsWithBrandAndTypeSpecifications(id);

            var product = await _unitOfWork.GetRepository<int, Product>().GetAsync(spec);
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
