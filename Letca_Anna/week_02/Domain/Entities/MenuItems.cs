using System;
using System.Collections.Generic;

namespace Persistence.EfCore
{
    public partial class MenuItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MenuId { get; set; }

        public virtual Menus Menu { get; set; }
    }
}
