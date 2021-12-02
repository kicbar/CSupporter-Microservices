using CSupporter.Services.Products.Models.Dtos;
using System.Collections.Generic;

namespace CSupporter.Services.Products.Services.IServices
{
    public interface IProductService
    {
        ProductDto GetEntireProduct(int productId);
        List<ProductDto> GetAllEntireProducts();
    }
}
