namespace FinanceTracker.Domain.ValueObjects
{
    public sealed class Location
    {
        public string Name { get; }
        public string Coordinates { get; }

        private Location() { }

        public Location(string name, string coordinates)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
        }

        public override bool Equals(object? obj)
            => obj is Location l && Name == l.Name && Coordinates == l.Coordinates;

        public override int GetHashCode() => HashCode.Combine(Name, Coordinates);
        public override string ToString() => $"{Name} ({Coordinates})";
    }
}
