using FinanceTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne<User>()
               .WithMany(u => u.Cards)
               .HasForeignKey("UserId")
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(c => c.Currency).IsRequired().HasMaxLength(4);
        builder.Property(c => c.Amount).IsRequired();
        builder.Property(c => c.Holder).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Expiry).IsRequired();
        builder.Property(c => c.Cvv).IsRequired().HasMaxLength(3);
        builder.Property(c => c.CurrencyLogo).IsRequired();
        builder.Property(c => c.ProviderLogo).IsRequired();

        // Seed data pentru UserId = 1 (test@gmail.com)
        builder.HasData(
            new
            {
                Id = 1,
                UserId = 1,
                Currency = "USD",
                Amount = 27119m,
                Holder = "Test User",
                Expiry = new DateTime(2035, 12, 1),
                Cvv = "**5",
                CurrencyLogo = "USD.png",
                ProviderLogo = "citigroup.png"
            },
            new
            {
                Id = 2,
                UserId = 1,
                Currency = "GBP",
                Amount = 12102m,
                Holder = "Test User",
                Expiry = new DateTime(2030, 8, 1),
                Cvv = "**9",
                CurrencyLogo = "GBP.png",
                ProviderLogo = "master card.png"
            },
            new
            {
                Id = 3,
                UserId = 1,
                Currency = "EURO",
                Amount = 7382m,
                Holder = "Test User",
                Expiry = new DateTime(2026, 6, 1),
                Cvv = "**2",
                CurrencyLogo = "EURO.png",
                ProviderLogo = "visa.png"
            }
        );
    }
}
