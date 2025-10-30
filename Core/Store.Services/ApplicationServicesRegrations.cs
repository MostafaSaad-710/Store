using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Services.Mapping.Products;
using Strore.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public static class ApplicationServicesRegrations
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection servicesc, IConfiguration cnfiguration)
        {

            servicesc.AddScoped<IServiceManager, ServiceManager>();
            servicesc.AddAutoMapper(M => M.AddProfile(new ProductProfile(cnfiguration )));

            return servicesc;
        }
    }
}
