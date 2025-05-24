namespace FinanceTracker.Domain.Models.Category
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; } // Add this line

        public void Create() { }
        public void Edit() { }
        public void Delete() { }
    }
}