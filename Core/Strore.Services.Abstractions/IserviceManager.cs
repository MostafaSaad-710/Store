using Strore.Services.Abstractions.Baskets;
using Strore.Services.Abstractions.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strore.Services.Abstractions
{
    public interface IServiceManager
    {
        IproductService productService { get;}
        IBascketServices  BascketServices { get; }

    }
}
