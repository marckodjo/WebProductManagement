using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProductManagement.Data;
using WebProductManagement.Models;

namespace WebProductManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound($"Produit avec l'ID {id} non trouvé.");

            return Ok(product);
        }


        [HttpGet("instock")]
        public async Task<IActionResult> GetInStockProducts()
        {
            var products = await _context.Products.Where(p => p.Stock > 0).ToListAsync();
            return Ok(products);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest("L'ID du produit ne correspond pas.");

            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
                return NotFound($"Produit avec l'ID {id} non trouvé.");

            // Mise à jour des propriétés
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            await _context.SaveChangesAsync();
            return Ok(existingProduct);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound($"Produit avec l'ID {id} non trouvé.");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok($"Produit '{product.Name}' supprimé avec succès.");
        }


    }
}