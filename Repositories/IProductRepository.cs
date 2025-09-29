using WebProductManagement.Models;

namespace WebProductManagement.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product?> GetProductById(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task SaveChangesAsync();
        Task<IEnumerable<Product>> GetInStockAsync();
    }
}
