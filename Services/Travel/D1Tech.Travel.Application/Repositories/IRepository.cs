using D1Tech.Travel.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.Travel.Application.Repositories
{
	public interface IRepository<T> where T : BaseEntity
	{
		DbSet<T> Table { get; }
	}
}
