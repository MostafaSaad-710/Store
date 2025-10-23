using Strore.Services.Abstractions.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strore.Services.Abstractions
{
    public interface IserviceManager
    {
        IproductService productService { get;}

    }
}
