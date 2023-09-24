using MVCStrategyPattern.Models;

namespace MVCStrategyPattern.Repository;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(string id);
    Task<List<Product>> GetAllByUserIdAsync(string userId);
    Task<Product> CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);

}
