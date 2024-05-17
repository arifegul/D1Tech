using D1Tech.Travel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.Travel.Persistence.Context
{
    public class D1TechTravelDbContext : DbContext
    {
        public D1TechTravelDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Travels> Travel { get; set; }
        public DbSet<TravelDetails> TravelDetails { get; set; }
    }
}
