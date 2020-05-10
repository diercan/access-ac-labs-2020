using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EfCore
{
    public partial class Menu
    {
        public Menu()
        {
            MenuItem = new HashSet<MenuItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<MenuItem> MenuItem { get; set; }
    }
}

