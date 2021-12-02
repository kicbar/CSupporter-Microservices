using CSupporter.Services.Products.Models;
using CSupporter.Services.Products.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSupporter.Services.Products.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProduct(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            if (product == null)
                return BadRequest();
            return product;
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Product createdProduct = _productRepository.AddProduct(product);

            return Created($"api/product/{createdProduct.ProductId}", null);
        }

        [HttpPut("{productId}")]
        public ActionResult<Product> UpdateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Product createdProduct = _productRepository.UpdateProduct(product);

            return Created($"api/product/{createdProduct.ProductId}", null);
        }

        [HttpGet("{productId}")]
        public ActionResult<bool> RemoveProductById(int productId)
        {
            return _productRepository.RemoveProduct(productId); ;
        }
    }
}
