using BE_2505_NetCoreAPI.Model;

namespace BE_2505_NetCoreAPI.Services
{
    public class ProductServiceImpl : IProductService
    {
        private readonly List<Product> _products;
        public ProductServiceImpl()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 100, Image = "image1.jpg" },
                new Product { Id = 2, Name = "Product 2", Price = 200, Image = "image2.jpg" },
                new Product { Id = 3, Name = "Product 3", Price = 300, Image = "image3.jpg" }
            };
        }
        public Task<List<Product>> GetListProduct()
        {
            return Task.FromResult(_products);
        }
    }
}
