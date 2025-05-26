using FinanceTracker.Domain.Interfaces;
using FinanceTracker.Domain.Models;
using FinanceTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Repositories
{
    public class CardRepository(FinanceTrackerDbContext context) : ICardRepository
    {
        public async Task<Card?> GetByIdAsync(int id)
        {
            return await context.Cards.FindAsync(id);
        }

        public async Task<IEnumerable<Card>> GetAllByUserIdAsync(int userId)
        {
            var user = await context.Users
                .Include(u => u.Cards)
                    .ThenInclude(c => c.AmountHistory)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user?.Cards ?? Enumerable.Empty<Card>();
        }

        public async Task AddAsync(Card card, int userId, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user == null) throw new Exception("User not found for adding card");

            user.Cards.Add(new Card
            {
                Amount = card.Amount,
                AmountHistory = card.AmountHistory,
                Currency = card.Currency,
                CurrencyLogo = card.CurrencyLogo,
                Cvv = card.Cvv,
                Expiry = card.Expiry,
                Holder = card.Holder,
                ProviderLogo = card.ProviderLogo
            });

            context.Update(user);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Card card, CancellationToken cancellationToken)
        {
            var existing = await context.Cards.FirstOrDefaultAsync(c => c.Id == card.Id, cancellationToken);

            if (existing == null)
                throw new Exception("Card not found for update");

            existing.Currency = card.Currency;
            existing.Amount = card.Amount;
            existing.Holder = card.Holder;
            existing.Expiry = card.Expiry;
            existing.Cvv = card.Cvv;
            existing.CurrencyLogo = card.CurrencyLogo;
            existing.ProviderLogo = card.ProviderLogo;

            context.Cards.Update(existing);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var card = await context.Cards.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            if (card == null) throw new Exception("User not found for adding card");

            context.Cards.Remove(card);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await context.Cards.AnyAsync(c => c.Id == id);
        }
    }
}
