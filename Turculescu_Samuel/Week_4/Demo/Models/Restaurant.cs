using System;
using System.Collections.Generic;

namespace Demo.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Employee = new HashSet<Employee>();
            Menu = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
    }
}
