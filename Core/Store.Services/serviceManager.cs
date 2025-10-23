using AutoMapper;
using Store.Domain.Contracts;
using Store.Services.Products;
using Strore.Services.Abstractions;
using Strore.Services.Abstractions.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class serviceManager(IUnitOfWork _unitOfWork, IMapper _mapper) : IserviceManager
    {
        public IproductService productService { get; } = new productService(_unitOfWork , _mapper);

    }
}
