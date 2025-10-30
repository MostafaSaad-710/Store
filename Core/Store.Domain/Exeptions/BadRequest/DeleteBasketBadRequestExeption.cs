using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Exeptions.BadRequest
{
    public class DeleteBasketBadRequestExeption() : BadRequestExeption("Invalid Operation When Delete The Basket")
    {
    }
}
