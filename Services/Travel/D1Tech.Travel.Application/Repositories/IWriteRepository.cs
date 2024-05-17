using D1Tech.Travel.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace D1Tech.Travel.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
	{
		Task<int> Create(T entity);
		Task<int> Delete(T entity);
		Task<int> Update(T entity);
	}
}
