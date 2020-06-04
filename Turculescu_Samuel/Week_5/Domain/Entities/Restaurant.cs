using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EfCore
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Employees = new List<Employee>();
            Menus = new List<Menu>();
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual List<Employee> Employees { get; set; }
        public virtual List<Menu> Menus { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
