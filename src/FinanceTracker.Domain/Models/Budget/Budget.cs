using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Domain.Models.Budget
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }

        public string UserId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Limit { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
