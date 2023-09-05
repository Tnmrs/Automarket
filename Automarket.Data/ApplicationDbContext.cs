using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Automarket.Domain.Entity;

namespace Automarket.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Car> Cars { get; set; }
    }
}
