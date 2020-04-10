using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateOrderOp
{
    class CreateOrderCmd
    {
        public DateTime DateTime { get; }
        public List<Menu> Menus { get; }
        public double Price { get; }
        public CreateOrderCmd(DateTime dateTime, List<Menu> menus, double price)
        {
            DateTime = dateTime;
            Menus = menus;
            Price = price;
        }
    }
}
