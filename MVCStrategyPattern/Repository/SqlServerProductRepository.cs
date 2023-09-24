using Microsoft.EntityFrameworkCore;
using MVCBaseProject.Models;
using MVCStrategyPattern.Models;

namespace MVCStrategyPattern.Repository;

public class SqlServerProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public SqlServerProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        product.Id = Guid.NewGuid().ToString();
        _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllByUserIdAsync(string userId)
    {
        return await _context.Products.Where(p => p.UserId == userId).ToListAsync();
    }

    public async Task<Product> GetByIdAsync(string id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);

        await _context.SaveChangesAsync();

    }
}
