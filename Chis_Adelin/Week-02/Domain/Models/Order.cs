using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Order
    {
        public DateTime DateTime { get; }
        public List<Menu> Menus{ get; }
        public double Price { get; }
        public Order(DateTime dateTime, List<Menu> menus, double price)
        {
            DateTime = dateTime;
            Menus = menus;
            Price = price;
        }
        
    }
}
