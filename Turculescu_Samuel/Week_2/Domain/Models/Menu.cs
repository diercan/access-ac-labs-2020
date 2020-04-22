using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Menu
    {
        public string MenuName { get; }
        public List<MenuItem> MenuItems { get; set; }

        public Menu(string menuName)
        {
            MenuName = menuName;
        }
    }
}
