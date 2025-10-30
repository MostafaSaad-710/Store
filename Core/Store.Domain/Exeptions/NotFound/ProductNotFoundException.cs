using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Exeptions.NotFound
{
    public class ProductNotFoundException(int id) : NotFoundException($"Poduct with id {id} was not found !!")
    {
    }
}
