using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TaxCalculator.Infrastructure.EF.Contexts
{
    public class TaxDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TaxDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DbConnection"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
          modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaxDbContext).Assembly);
    }
}
