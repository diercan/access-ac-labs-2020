namespace Domain.Models
{
    public class MenuItem
    {
        public string Name { get; }
        public string Ingredients { get; }
        public string Allergens { get; }
        public uint Price { get; }
        public MenuItem(string name, string ingredients, string allergens, uint price)
        {
            Name = name;
            Ingredients = ingredients;
            Allergens = allergens;
            Price = price;
        }
    }
}