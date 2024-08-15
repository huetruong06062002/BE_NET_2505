using BE_2505_NetCoreAPI.Model;

namespace BE_2505_NetCoreAPI.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetListProduct();
    }
}
