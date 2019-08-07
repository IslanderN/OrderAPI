using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrderApi.Repository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private readonly DbContext context;
		private readonly DbSet<TEntity> entity;
		public GenericRepository(OrderContext context)
		{
			this.context = context;
			this.entity = context.Set<TEntity>();
		}

		public void Add(TEntity item)
		{
			this.entity.Add(item);
		}

		public IQueryable<TEntity> GetQuery()
		{
			return this.entity.AsNoTracking();
		}

		public void Update(TEntity item)
		{
			this.entity.Update(item);
		}

		public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return Include(includeProperties).ToList();
		}

		public IQueryable<TEntity> GetWithIncludeQuery(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return Include(includeProperties);
		}

		private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = this.entity.AsNoTracking();
			return includeProperties
				.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		}
		public void SaveChanges()
		{
			this.context.SaveChanges();
		}
	}
}
