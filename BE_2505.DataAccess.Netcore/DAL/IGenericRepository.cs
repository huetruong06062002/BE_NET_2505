

namespace BE_2505.DataAccess.Netcore.DAL
{
	public interface IGenericRepository<T> where T: class
	{
		Task<List<T>> GetAll();

		Task<int> InsertUpdate(T entity);
	}
}
