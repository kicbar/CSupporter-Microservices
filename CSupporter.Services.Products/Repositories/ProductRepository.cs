using CSupporter.Services.Products.Data.DbContexts;
using CSupporter.Services.Products.Models;
using CSupporter.Services.Products.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace CSupporter.Services.Products.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public List<Product> GetAllProducts()
        {
            return _productDbContext.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _productDbContext.Products.Where(product => product.ProductId == productId).FirstOrDefault();
        }

        public Product AddProduct(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            Product productExist = _productDbContext.Products.Where(product => product.ProductId == product.ProductId).FirstOrDefault();

            if (productExist != null)
            { 
                _productDbContext.Products.Update(product);
                _productDbContext.SaveChanges();
            }
            return product;
        }

        public bool RemoveProduct(int productId)
        {
            Product productExist = _productDbContext.Products.Where(product => product.ProductId == product.ProductId).FirstOrDefault();

            if (productExist != null)
            {
                _productDbContext.Products.Remove(productExist);
                _productDbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
