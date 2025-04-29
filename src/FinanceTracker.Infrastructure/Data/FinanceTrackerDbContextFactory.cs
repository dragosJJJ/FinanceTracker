using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinanceTracker.Infrastructure.Data
{
    public class FinanceTrackerDbContextFactory : IDesignTimeDbContextFactory<FinanceTrackerDbContext>
    {
        public FinanceTrackerDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();

            if (!File.Exists(Path.Combine(basePath, "appsettings.json")))
            {
                basePath = Path.Combine(basePath, "..", "FinanceTracker.API");
            }

            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<FinanceTrackerDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new FinanceTrackerDbContext(optionsBuilder.Options);
        }
    }
}
