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

        public override string ToString()
        {
            return "MenuItem name: " + Name + ", price: " + Price + "\n";
        }
    }
}