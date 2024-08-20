using NetcoreAPI_BTVN21.Models;

namespace NetcoreAPI_BTVN21.Service
{
    public class ProductGenericRepository : IProductGenericRepository<Product>
    {
        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> InserUpdate(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
