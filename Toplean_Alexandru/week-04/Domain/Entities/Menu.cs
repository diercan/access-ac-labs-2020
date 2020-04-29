using System;
using System.Collections.Generic;

namespace Persistence.EfCore
{
    public partial class Menu
    {
        public Menu()
        {
            MenuItem = new HashSet<MenuItem>();
        }

        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string MenuType { get; set; }
        public bool Visibility { get; set; }
        public string Hours { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<MenuItem> MenuItem { get; set; }
    }
}
