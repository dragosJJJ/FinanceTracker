namespace FinanceTracker.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasData(
                Category.CreateCategoryForSeedinf(1, "Income"),
                Category.CreateCategoryForSeedinf(2, "Expenses"),
                Category.CreateCategoryForSeedinf(3, "Investments")
            );
        }
    }
}
