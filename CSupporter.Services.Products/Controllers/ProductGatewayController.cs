using CSupporter.Services.Products.Models.Dtos;
using CSupporter.Services.Products.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSupporter.Services.Products.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductGatewayController : Controller
    {
        private readonly IProductService _productService;

        public ProductGatewayController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{productId}")]
        [ActionName("GetCompleteProduct")]
        public ActionResult<ProductDto> GetCompleteProduct(int productId)
        {
            return _productService.GetEntireProduct(productId);
        }

        [HttpGet]
        [ActionName("GetAllEntireProducts")]
        public ActionResult<List<ProductDto>> GetAllEntireProducts()
        {
            return _productService.GetAllEntireProducts();
        }
    }
}
