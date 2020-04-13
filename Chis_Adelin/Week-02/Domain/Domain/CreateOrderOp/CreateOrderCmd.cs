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
        public uint Price { get; }
        public CreateOrderCmd(DateTime dateTime, List<Menu> menus, uint price)
        {
            DateTime = dateTime;
            Menus = menus;
            Price = price;
        }
    }
}
