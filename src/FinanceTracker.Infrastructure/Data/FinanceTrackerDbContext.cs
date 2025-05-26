using FinanceTracker.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Data
{
    public class FinanceTrackerDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanceTrackerDbContext).Assembly);
        }
    }
}
