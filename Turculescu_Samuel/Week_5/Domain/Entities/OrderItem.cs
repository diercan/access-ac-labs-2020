using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EfCore
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MenuItemId { get; set; }
        public int OrderId { get; set; }
        public uint Quantity { get; set; }
        public string SpecialRequests { get; set; }      
        public double Price { get; set; }

        public virtual MenuItem MenuItem { get; set; }
        public virtual Order Order { get; set; }
    }
}
