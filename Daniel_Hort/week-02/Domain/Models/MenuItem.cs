namespace Domain.Models
{
    public class MenuItem
    {
        public float Price { get; }
        public string Name { get; }

        public MenuItem(string name, float price) {
            Name = name;
            Price = price;
        }
    }
}