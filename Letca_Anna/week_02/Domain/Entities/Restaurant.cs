using System;
using System.Collections.Generic;

namespace Persistence.EfCore
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Employees = new HashSet<Employees>();
            Menus = new HashSet<Menus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Menus> Menus { get; set; }
    }
}
