namespace Domain.Models
{
    public class MenuItem
    {
        public string Name { get; }
        public double Price { get; }
        public MenuItem(string name, double price) {
            Price = price;
            Name = name;
        }
    }
}