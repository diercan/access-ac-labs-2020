namespace Domain.Models
{
    public class MenuItem
    {
        public string Name { get; }
        public string Ingredients { get; }
        public string Allergens { get; }
        public double Price { get; }
        public MenuItem(string name, string ingredients, string allergens, double price)
        {
            Name = name;
            Ingredients = ingredients;
            Allergens = allergens;
            Price = price;
        }
    }
}