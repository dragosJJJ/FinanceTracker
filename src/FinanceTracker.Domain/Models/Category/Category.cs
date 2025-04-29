namespace FinanceTracker.Domain.Models.Category
{
    public class Category
    {
        private ICollection<Transaction.Transaction> transactions;
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Budget.Budget> Budgets { get; set; }
        public ICollection<Transaction.Transaction> Transactions { get => transactions; set => transactions = value; }
    }
}
