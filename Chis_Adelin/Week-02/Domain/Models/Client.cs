namespace Domain.Models
{
    public class Client
    {
        public string Name { get; }
        public Cart Cart { get; }

        public Client(string name)
        {
            Name = name;
            Cart = new Cart();
        }
    }
}