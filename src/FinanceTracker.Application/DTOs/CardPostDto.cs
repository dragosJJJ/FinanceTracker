namespace FinanceTracker.Application.DTOs
{
    public class CardPostDto
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string Holder { get; set; }
        public DateTime Expiry { get; set; }
        public string Cvv { get; set; }
        public string CurrencyLogo { get; set; }
        public string ProviderLogo { get; set; }
    }
}
