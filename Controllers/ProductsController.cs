using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProductManagement.Data;
using WebProductManagement.Models;
using WebProductManagement.Repositories;

namespace WebProductManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
       // private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;

        public ProductsController(AppDbContext context, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            //_context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProduct();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);

            if (product == null)
                return NotFound($"Produit avec l'ID {id} non trouvé.");

            return Ok(product);
        }


        [HttpGet("instock")]
        public async Task<IActionResult> GetInStockProducts()
        {
            var products = await _productRepository.GetInStockAsync();
            return Ok(products);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest("L'ID du produit ne correspond pas.");

            var existingProduct = await _productRepository.GetProductById(id);
            if (existingProduct == null)
                return NotFound($"Produit avec l'ID {id} non trouvé.");

            // Mise à jour des propriétés
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            await _productRepository.UpdateAsync(existingProduct);
            await _productRepository.SaveChangesAsync();
            return Ok(existingProduct);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
                return NotFound($"Produit avec l'ID {id} non trouvé.");

            await _productRepository.DeleteAsync(product);
            await _productRepository.SaveChangesAsync();

            return Ok($"Produit '{product.Name}' supprimé avec succès.");
        }


    }
}