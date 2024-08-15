using NetcoreAPI_BTVN21.Models;

namespace NetcoreAPI_BTVN21.Service
{
    public interface  IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> SearchProductsByName(string name);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
