using System;
using System.Collections.Generic;

namespace Persistence.EfCore
{
    public partial class Menus
    {
        public Menus()
        {
            MenuItems = new HashSet<MenuItems>();
        }

        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<MenuItems> MenuItems { get; set; }
    }
}
