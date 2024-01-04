using Microsoft.AspNetCore.Mvc;
using test_asp.net_Api.Interfaces;
using test_asp.net_Api.Models;
using test_asp.net_Api.Repositories;

namespace test_asp.net_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAll();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var newProduct = new Product()
            {
                Name = product.Name,
                Category = product.Category,
                Price = product.Price
            };

            var products = await _unitOfWork.Products.Add(newProduct);
            await _unitOfWork.Save();

            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _unitOfWork.Products.GetById(id);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var productToUpdate = await _unitOfWork.Products.GetById(product.Id);

            if (productToUpdate == null)
                return NotFound();

            productToUpdate.Name = product.Name;
            productToUpdate.Category = product.Category;
            productToUpdate.Price = product.Price;

            await _unitOfWork.Save();

            return Ok(productToUpdate);
        }
    }
}
