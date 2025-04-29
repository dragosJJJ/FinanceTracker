namespace FinanceTracker.Domain.Models.Category
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Budget.Budget> Budgets { get; set; }
        private ICollection<Transaction.Transaction> transactions;
        public ICollection<Transaction.Transaction> Transactions { get => transactions; set => transactions = value; }

        public static Category CreateCategoryForSeeding(int id, string name)
        { 
            return new Category
            { 
                Id = id,
                Name = name
            };
        }
    }
}
