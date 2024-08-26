﻿using BTVN_24.Data;
using BTVN_24.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BTVN_24.Repository.Implement
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly UserContext _context;
		private readonly DbSet<T> _dbSet;

		public Repository(UserContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Update(T entity)
		{
			_dbSet.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

		public void Delete(T entity)
		{
			if (_context.Entry(entity).State == EntityState.Detached)
			{
				_dbSet.Attach(entity);
			}
			_dbSet.Remove(entity);
		}
	}
}
