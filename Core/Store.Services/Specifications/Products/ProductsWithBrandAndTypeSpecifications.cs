using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Specifications.Products
{
    public class ProductsWithBrandAndTypeSpecifications : BaseSpecifications<int , Product>
    {
        public ProductsWithBrandAndTypeSpecifications(int id) : base(p => p.Id == id)
        {
            //Includes.Add(p  => p.Brand);
            //Includes.Add(p  => p.Type);

            ApplyInclude();
        }
        public ProductsWithBrandAndTypeSpecifications(int? brandId, int? TypeId, string? sort , string? search) : base
            (
                   p =>
                   (!brandId.HasValue || p.BrandId == brandId)
                   &&
                   (!TypeId.HasValue || p.TypeId == TypeId)
                   &&
                   ( string.IsNullOrEmpty(search) || p.Name.ToLower().Contains(search.ToLower()))

            
            )
        {
            //Includes.Add(p => p.Brand);
            //Includes.Add(p => p.Type);
            ApplySorting(sort);

            ApplyInclude();




        }
        private void ApplyInclude()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Type);
        }
        private void ApplySorting(string? sort)
        {
            //Priceasc
            //Pricedesc
            //nameasc
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "priceasc":
                        //OrderBy = p => p.Price;
                        AddOrderBy(p => p.Price);
                        break;
                    case "pricedesc":
                        //OrderByDescending = p => p.Price;
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        //OrderBy = p => p.Name;
                        AddOrderBy(p => p.Name);
                        break;

                }

            }
            else
            {
                //OrderBy = p => p.Name;
                AddOrderBy(p => p.Name);
            }
        }
    }
}
