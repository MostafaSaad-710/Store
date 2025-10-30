using AutoMapper;
using Store.Domain.Contracts;
using Store.Services.Baskets;
using Store.Services.Products;
using Strore.Services.Abstractions;
using Strore.Services.Abstractions.Baskets;
using Strore.Services.Abstractions.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class ServiceManager(IUnitOfWork _unitOfWork, IMapper _mapper, IBasketRepository _basketRepository) : IServiceManager
    {
        public IproductService productService { get; } = new productService(_unitOfWork , _mapper);

        public IBascketServices BascketServices { get; } = new BascketServices(_basketRepository, _mapper);
    }
}
