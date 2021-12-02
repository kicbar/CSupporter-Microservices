using CSupporter.Services.Products.Data.DbContexts;
using CSupporter.Services.Products.Models;
using CSupporter.Services.Products.Models.Dtos;
using CSupporter.Services.Products.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSupporter.Services.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _productDbContext;

        public ProductService(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public List<ProductDto> GetAllEntireProducts()
        {
            throw new NotImplementedException();
        }

        public ProductDto GetEntireProduct(int productId)
        {
            Product product = _productDbContext.Products.Where(product => product.ProductId == product.ProductId).FirstOrDefault();
            Warehouse warehouse = _productDbContext.WarehouseAmounts.Where(warehouse => warehouse.ProductId == productId).FirstOrDefault();

            ProductDto productDto = new ProductDto() 
            { 
                ProductId = product.ProductId,
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
                Details = product.Details,
                Amount = warehouse.Amount,
                Unit = warehouse.Unit
            };

            return productDto;
        }
    }
}
