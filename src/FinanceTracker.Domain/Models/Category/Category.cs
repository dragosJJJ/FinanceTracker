using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Domain.Models.Category
{
    public class Category
    {
        private ICollection<Transaction> transactions;

        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }


        public ICollection<Budget> Budgets { get; set; }
        public ICollection<Transaction> Transactions { get => transactions; set => transactions = value; }

    }
}
