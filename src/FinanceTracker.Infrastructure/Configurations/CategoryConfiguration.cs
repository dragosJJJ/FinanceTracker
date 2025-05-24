using FinanceTracker.Domain.Models.Category;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne<User>()
               .WithMany(u => u.Categories)
               .HasForeignKey("UserId")
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(c => c.Title).IsRequired();
        builder.Property(c => c.Description);
    }
}