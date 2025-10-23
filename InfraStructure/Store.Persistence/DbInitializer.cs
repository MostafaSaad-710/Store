using Microsoft.EntityFrameworkCore;
using Store.Domain.Contracts;
using Store.Domain.Entities.Products;
using Store.Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Persistence
{
    // CLR
    // We Call 'InitializeAsync' every time i run app so i call it in program

    public class DbInitializer(StoreDbContext _context) : IDbInitializer
    {

        #region Primary Constractor
        // We Use Primary Constractor Instead

        //private readonly StoreDbContext _context;
        //public DbInitializer(StoreDbContext context)
        //{
        //    _context = context;
        //}   
        #endregion


        // We Call 'DbInitializer' every time i run app so i call it in program

        public async Task InitializeAsync()
        {
            // Create DB (To Access DB, I need Object From Class that represent database)
            // Update Db
            if(_context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Any())
            {
               await _context.Database.MigrateAsync();
            }

            // Data Seeding

            // ProductBrands

            if(!_context.ProductBrands.Any())
            {
                // 1. Read All Data From Json File 'brands.Json'
                var brandsdata = await File.ReadAllTextAsync(@"..\InfraStructure\Store.Persistence\Data\DataSeeding\brands.json");

                // 2. Convert the Jasonstring To List<ProductBrands>
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);

                // Add List To The Db
                if (brands is not null && brands.Count > 0)
                {
                    await _context.ProductBrands.AddRangeAsync(brands);
                }

            }

            // ProductTypes

            if (!_context.ProductTypes.Any())
            {
                // 1. Read All Data From Json File 'brands.Json'
                var typesdata = await File.ReadAllTextAsync(@"..\InfraStructure\Store.Persistence\Data\DataSeeding\types.json");

                // 2. Convert the Jasonstring To List<ProductBrands>
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);

                // Add List To The Db
                if (types is not null && types.Count > 0)
                {
                    await _context.ProductTypes.AddRangeAsync(types);
                }

            }

            // Product

            if (!_context.Products.Any())
            {
                // 1. Read All Data From Json File 'brands.Json'
                var prudactdata = await File.ReadAllTextAsync(@"..\InfraStructure\Store.Persistence\Data\DataSeeding\products.json");

                // 2. Convert the Jasonstring To List<ProductBrands>
                var products = JsonSerializer.Deserialize<List<Product>>(prudactdata);

                // Add List To The Db
                if (products is not null && products.Count > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                }

                await _context.SaveChangesAsync();

            }
        }
    }
}
