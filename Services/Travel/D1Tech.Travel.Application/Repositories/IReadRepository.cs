using D1Tech.Travel.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.Travel.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
	{
		Task<List<T>> GetAll();
		Task<List<T>> GetAllIncluding(params Expression<Func<T, object>>[] includes);
		Task<T> Find(Expression<Func<T, bool>> expression);
	}
}
