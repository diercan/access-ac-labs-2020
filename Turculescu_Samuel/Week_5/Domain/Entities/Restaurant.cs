using System;
using System.Collections.Generic;

namespace Persistence.EfCore
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Employees = new HashSet<Employee>();
            Menus = new List<Menu>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
