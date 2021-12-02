using CSupporter.Services.Products.Models;
using System.Collections.Generic;

namespace CSupporter.Services.Products.Repositories.IRepositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
        Product AddProduct(Product product, int? amount = null);
        Product UpdateProduct(Product product);
        bool RemoveProduct(int productId);
    }
}
