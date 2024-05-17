using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.User.Application.Mapping
{
	public class ObjectMapper
	{
		private static readonly Lazy<IMapper> lazy = new(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<D1TechUserAutoMapperProfile>();
			});
			return config.CreateMapper();
		});
		public static IMapper Mapper => lazy.Value;
	}
}
