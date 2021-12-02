using CSupporter.Services.Products.Data.DbContexts;
using CSupporter.Services.Products.Models;
using System.Collections.Generic;
using System.Linq;

namespace CSupporter.Services.Products.Data
{
    public class ProductsSeeder
    {
        private readonly ProductDbContext _productDbContext;

        public ProductsSeeder(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public void Seed()
        {
            if (_productDbContext.Database.CanConnect())
            {
                if (!_productDbContext.Products.Any())
                    InsertSampleData();
            }
        }

        private void InsertSampleData()
        {
            var products = new List<Product>
            {
                new Product()
                {
                    Name = "Laptop Lenovo",
                    Category = "Electronics",
                    Price = 3000.00,
                    Details = "Intel Core i5, 240SSD, 16GB RAM",
                    WarehouseAmounts = new Warehouse
                    {
                        Amount = 100
                    }
                },
                new Product()
                {
                    Name = "IPhone 6S",
                    Category = "Electronics",
                    Price = 1200.00,
                    Details = "Apple A9 1.85GHz dual-core, 48Mpx, 4/64GB",
                    WarehouseAmounts = new Warehouse
                    {
                        Amount = 20
                    }
                },
                new Product()
                {
                    Name = "Headphone Huawei AM61",
                    Category = "Electronics",
                    Price = 120.00,
                    Details = "Bluetooth, microUSB, microphone",
                    WarehouseAmounts = new Warehouse
                    {
                        Amount = 30
                    }
                }
            };

            _productDbContext.AddRange(products);
            _productDbContext.SaveChanges();
        }
    }
}
