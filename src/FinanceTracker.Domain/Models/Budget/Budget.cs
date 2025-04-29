using FinanceTracker.Domain.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Domain.Models.Budget
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }

        public string UserId { get; set; }

        public decimal Limit { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public int CategoryId { get; set; }

        public Category.Category Category { get; set; }

    }
}
