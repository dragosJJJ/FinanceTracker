namespace FinanceTracker.Domain.Models.Transaction
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category.Category Category { get; set; }
        public string Location { get; set; }

    }
}
