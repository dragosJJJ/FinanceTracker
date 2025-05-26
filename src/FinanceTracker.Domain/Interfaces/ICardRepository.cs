using FinanceTracker.Domain.Models;

namespace FinanceTracker.Domain.Interfaces
{
    public interface ICardRepository
    {
        Task<Card?> GetByIdAsync(int id);
        Task<IEnumerable<Card>> GetAllByUserIdAsync(int userId);
        Task AddAsync(Card card, int userId, CancellationToken cancellationToken);
        Task UpdateAsync(Card card, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(int id);
    }
}
