using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Persistence.EfCore
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            OrderItems = new List<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Allergens { get; set; }
        public uint TotalQuantity { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        public int MenuId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Menu Menu { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }
}

