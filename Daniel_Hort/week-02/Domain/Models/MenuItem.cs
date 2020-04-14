namespace Domain.Models
{
    public class MenuItem
    {
        public uint Price { get; }
        public string Name { get; }

        public MenuItem(string name, uint price) {
            Name = name;
            Price = price;
        }
    }
}