using Microsoft.EntityFrameworkCore;
using WebProductManagement.Data;
using WebProductManagement.Models;

namespace WebProductManagement.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
           _context.Products.Update(product);
        }

        public async Task<IEnumerable<Product>> GetInStockAsync()
        {
            return await _context.Products.Where(p => p.Stock > 0).ToListAsync();
        }
    }
}
