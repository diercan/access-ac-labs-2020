using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Order
    {
        public DateTime DateTime { get; }
        public List<Menu> Menus{ get; }
        public uint Price { get; }
        public Order(DateTime dateTime, List<Menu> menus, uint price)
        {
            DateTime = dateTime;
            Menus = menus;
            Price = price;
        }
        
    }
}
