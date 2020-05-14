using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EfCore
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Allergens { get; set; }
        public uint TotalQuantity { get; set; }
        public double Price { get; set; }
        public bool Availability { get; set; }
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

