using Catalog.API.Models;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);

        Task<bool> DeleteProduct(string id);

        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProductById(string id);

        Task<IEnumerable<Product>> GetProductByName(string name);

        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);

        Task<bool> UpdateProduct(Product product); 
    }
}
