﻿using Microsoft.EntityFrameworkCore;
using Online_Learning.Models.Entities;
using Online_Learning.Repositories.Interfaces;

namespace OnlineLearning.Repositories.Implementations
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected readonly OnlineLearningContext _context;
		protected readonly DbSet<T> _dbSet;

		public BaseRepository(OnlineLearningContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public async Task<T?> GetByIdAsync(string? id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T> AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<T> GetByIdAsync(params object[] keyValues)
		{
			if (keyValues.Length == 2) // Nếu có 2 khóa chính
			{
				var key1 = keyValues[0];
				var key2 = keyValues[1];

				return await _dbSet.FirstOrDefaultAsync(e => EF.Property<long>(e, "CourseId") == (long)key1
														   && EF.Property<long>(e, "CategoryId") == (long)key2);
			}

			return await _dbSet.FindAsync(keyValues);
		}
	}
}
