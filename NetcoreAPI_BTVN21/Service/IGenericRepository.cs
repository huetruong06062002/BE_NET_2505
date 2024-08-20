namespace NetcoreAPI_BTVN21.Service
{
    public interface IGenericRepository<T> 
    {
        Task<List<T>> GetAll();
        Task<int> InserUpdate(T entity);
    }
}
