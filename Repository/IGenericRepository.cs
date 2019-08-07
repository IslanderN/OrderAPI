using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderApi.Repository
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> GetQuery();
		void Add(TEntity item);
		void Update(TEntity item);
		void SaveChanges();

		IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
		IQueryable<TEntity> GetWithIncludeQuery(params Expression<Func<TEntity, object>>[] includeProperties);
	}
}
