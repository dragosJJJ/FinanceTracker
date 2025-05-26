using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.Domain.Models;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.OwnsOne(t => t.Amount);
        builder.OwnsOne(t => t.Location);

        builder.Property(t => t.TransactionKind).HasConversion<string>();

        builder.HasOne(t => t.PaymentMethod).WithMany().HasForeignKey(t => t.PaymentMethodId);
    }
}