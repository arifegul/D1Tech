using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.User.Persistence
{
	static class Configuration
	{
		static public string ConnectionString
		{
			get
			{
				ConfigurationManager configurationManager = new();
				configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../D1Tech.User.API"));
				configurationManager.AddJsonFile("appsettings.json");

				return configurationManager.GetConnectionString("DefaultConnection");
			}
		}
	}
}
