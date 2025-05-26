namespace FinanceTracker.Domain.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Currency { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Holder { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
        public string Cvv { get; set; } = string.Empty;
        public string CurrencyLogo { get; set; } = string.Empty;
        public string ProviderLogo { get; set; } = string.Empty;
        public ICollection<CardAmountHistory> AmountHistory { get; set; } = [];
        public void Validate() { }
    }
}
