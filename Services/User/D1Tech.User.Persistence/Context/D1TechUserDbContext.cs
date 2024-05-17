using D1Tech.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.User.Persistence.Context
{
    public class D1TechUserDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Users> User { get; set; }
    }
}
