using Microsoft.EntityFrameworkCore;
using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DBContext;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private BE_25_05_DbContext _context;

		public GenericRepository(BE_25_05_DbContext context)
		{
			_context = context;
		}

		public async Task<List<T>> GetAll()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<int> InsertUpdate(T entity)
		{
			_context.Add(entity);
			return await _context.SaveChangesAsync();
		}
	}
}
