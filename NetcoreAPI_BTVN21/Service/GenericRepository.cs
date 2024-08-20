
namespace NetcoreAPI_BTVN21.Service
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> InserUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
