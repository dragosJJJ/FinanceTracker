using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.DTOs
{
    public class CardHistoryDto
    {
        public string Label { get; set; } = default!;
        public List<decimal> Data { get; set; } = [];
        public string BorderColor { get; set; } = "blue";
        public int BorderWidth { get; set; } = 2;

        public void SetBorderColor(string currency)
        {
            this.BorderColor = currency switch
            {
                "USD" => CurrencyColor.Red.ToString().ToLower(),
                "GBP" => CurrencyColor.Green.ToString().ToLower(),
                "EURO" or "EUR" => CurrencyColor.Blue.ToString().ToLower(),
                _ => CurrencyColor.Gray.ToString().ToLower()
            };
        }
    }
}
