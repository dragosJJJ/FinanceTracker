namespace FinanceTracker.Domain.ValueObjects
{
    public sealed class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Money() { }

        public Money(decimal amount, string currency)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.");

            Amount = amount;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public override bool Equals(object? obj)
            => obj is Money m && Amount == m.Amount && Currency == m.Currency;

        public override int GetHashCode() => HashCode.Combine(Amount, Currency);

        public override string ToString() => $"{Amount} {Currency}";
    }
}
