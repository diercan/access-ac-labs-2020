using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndPay.Web.Models
{
    public class Menu
    {
        public Menu()
        {
            MenuItems = new List<MenuItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }

    public class MenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
