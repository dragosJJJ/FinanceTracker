namespace FinanceTracker.Domain.Models
{
    public class CardAmountHistory
    {
        public int Id { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        public decimal Amount { get; set; }
    }
}
