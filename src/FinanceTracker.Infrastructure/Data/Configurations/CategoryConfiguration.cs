using FinanceTracker.Domain.Models.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasData(
                Category.CreateCategoryForSeeding(1, "Income"),
                Category.CreateCategoryForSeeding(2, "Expenses"),
                Category.CreateCategoryForSeeding(3, "Investments")
            );
        }
    }
}
