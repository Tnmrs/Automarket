using System;
using Automarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Automarket.Data
{
    public class ApplicationDbContext : DbContext
    {
    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("DefaultConnection");
        }

        public DbSet<Car> Cars { get; set; }
    }
}

