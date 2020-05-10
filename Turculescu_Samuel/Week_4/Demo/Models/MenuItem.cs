using System;
using System.Collections.Generic;

namespace Demo.Models
{
    public partial class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Allergens { get; set; }
        public int? TotalQuantity { get; set; }
        public decimal? Price { get; set; }
        public bool? Availability { get; set; }
        public int? MenuId { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
