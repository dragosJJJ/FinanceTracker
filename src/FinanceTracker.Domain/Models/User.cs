using Microsoft.AspNetCore.Identity;

namespace FinanceTracker.Domain.Models
{
    public class User : IdentityUser<int>
    {
        public ICollection<Transaction> Transactions { get; set; } = [];
        public ICollection<Budget> Budgets { get; set; } = [];
        public ICollection<PaymentMethod> PaymentMethods { get; set; } = [];
        public ICollection<Card> Cards { get; set; } = [];
        public ICollection<Category> Categories { get; set; } = [];

        public void Register() { }
        public void Login() { }
        public void Logout() { }
        public void ResetPassword() { }
        public void UpdateProfile() { }
    }
}
