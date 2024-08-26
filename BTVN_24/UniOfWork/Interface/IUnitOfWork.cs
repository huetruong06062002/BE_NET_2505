using BTVN_24.Models;
using BTVN_24.Repository.Interface;

namespace BTVN_24.UniOfWork.Interface
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<User> Users { get; }
		IRepository<Product> Products { get; }
		Task<int> SaveChangesAsync();
	}

}
