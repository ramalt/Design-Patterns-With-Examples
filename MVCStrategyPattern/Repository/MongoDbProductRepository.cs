using MongoDB.Driver;
using MVCStrategyPattern.Models;

namespace MVCStrategyPattern.Repository;

public class MongoDbProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _productCollection;

    public MongoDbProductRepository(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("MongoDb");

        var client = new MongoClient(connectionString);
        var db = client.GetDatabase("ProductDb");
        _productCollection = db.GetCollection<Product>("Products");
    }

    public async Task<Product> CreateAsync(Product product)
    {
        await _productCollection.InsertOneAsync(product);

        return product;
    }

    public async Task DeleteAsync(Product product)
    {
        await _productCollection.DeleteOneAsync(p => p.Id == product.Id);
    }

    public async Task<List<Product>> GetAllByUserIdAsync(string userId)
    {
        return await _productCollection.Find(p => p.UserId == userId).ToListAsync();
    }

    public async Task<Product> GetByIdAsync(string id)
    {
        return await _productCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        await _productCollection.FindOneAndReplaceAsync(p => p.Id == product.Id, product);
    }
}
