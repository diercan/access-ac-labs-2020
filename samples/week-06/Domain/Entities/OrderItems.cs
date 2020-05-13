using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Persistence.EfCore
{
    public partial class OrderItems
    {
        public OrderItems()
        {
        }

        public OrderItems(int orderID, int menuID, int menuItemID, int quantity, string comment)
        {
            OrderId = orderID;
            MenuId = menuID;
            MenuItemId = menuItemID;
            Quantity = quantity;
            Comment = comment;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Menu Menu { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual MenuItem MenuItem { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Order Order { get; set; }
    }
}