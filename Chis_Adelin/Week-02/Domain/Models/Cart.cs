using System.Collections.Generic;

namespace Domain.Models
{
    public class Cart
    {
        public uint price { get; set; }
        public List<MenuItem> MenuItems { get; }

        public Cart()
        {
            price = 0;
            MenuItems = new List<MenuItem>();
        }
    }
}