using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Cart
    {
        public List<MenuItem> MenuItems { get; }
        public double TotalPrice { get; set; } = 0;
        public Cart()
        {
            MenuItems = new List<MenuItem>();
        }
        public double CalculateTotalPrice()
        {
            foreach(MenuItem item in MenuItems)
            {
                TotalPrice += item.Price;
            }
            return TotalPrice;
        }
    }
}
