using Catalog.API.Data;
using Catalog.API.Models;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _dbContext;

        public ProductRepository(ICatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProduct(Product product)
        {
            await _dbContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(c => c.Id, id);
            DeleteResult deleteResult = await _dbContext.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _dbContext.Products.Find(c => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(c => c.Category, categoryName);

            return await _dbContext.Products.Find(filter).ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _dbContext.Products.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(c => c.Name, name);

            return await _dbContext.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _dbContext.Products.ReplaceOneAsync(filter: c => c.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
