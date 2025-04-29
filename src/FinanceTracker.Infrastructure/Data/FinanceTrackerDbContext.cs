using FinanceTracker.Domain.Models.Budget;
using FinanceTracker.Domain.Models.Category;
using FinanceTracker.Domain.Models.Transaction;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Data
{
    public class FinanceTrackerDbContext : DbContext
    {
        public FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
    }
}
