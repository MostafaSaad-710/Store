using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Exeptions.NotFound
{
    public class BasketNotFoundException(string id) : NotFoundException($"Baasket With Key {id} Is Found")
    {

    }
}
