using WebMVC_Netcore.Models;

namespace WebMVC_Netcore.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
    }
}
