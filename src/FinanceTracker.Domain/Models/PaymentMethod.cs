using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Domain.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = new User();
        public PaymentMethodType Type { get; set; }

        public void Add() { }
        public void Remove() { }
    }
}
