using CSupporter.Services.Products.Models;
using CSupporter.Services.Products.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSupporter.Services.Products.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductAPIController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ActionName("GetProducts")]
        public ActionResult<List<Product>> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }

        [HttpGet("{productId}")]
        [ActionName("GetProduct")]
        public ActionResult<Product> GetProduct(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            if (product == null)
                return BadRequest();
            return product;
        }

        [HttpPost]
        [ActionName("CreateProduct")]
        public ActionResult<Product> CreateProduct([FromBody] Product product, int? amount = null)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Product createdProduct = _productRepository.AddProduct(product, amount);

            return Created($"api/product/{createdProduct.ProductId}", null);
        }

        [HttpPut]
        [ActionName("UpdateProduct")]
        public ActionResult<Product> UpdateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Product createdProduct = _productRepository.UpdateProduct(product);

            return Created($"api/product/{createdProduct.ProductId}", null);
        }

        [HttpDelete("{productId}")]
        [ActionName("RemoveProductById")]
        public ActionResult<bool> RemoveProductById(int productId)
        {
            return _productRepository.RemoveProduct(productId); ;
        }
    }
}
