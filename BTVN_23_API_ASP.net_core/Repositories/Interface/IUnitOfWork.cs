


namespace BTVN_23_API_ASP.net_core.Repositories.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        Task<int> CompleteAsync();
    }
}
