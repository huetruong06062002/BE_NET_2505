using BTVN_24.Data;
using BTVN_24.Models;
using BTVN_24.Repository.Implement;
using BTVN_24.Repository.Interface;
using BTVN_24.UniOfWork.Interface;

namespace BTVN_24.UniOfWork.Implement
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly UserContext _context;
		private IRepository<User> _userRepository;
		private IRepository<Product> _productRepository;

		public UnitOfWork(UserContext context)
		{
			_context = context;
		}

		public IRepository<User> Users => _userRepository ??= new Repository<User>(_context);
		public IRepository<Product> Products => _productRepository ??= new Repository<Product>(_context);

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}

}
