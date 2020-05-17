using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class OrderItemAgg
    {
        public OrderItems OrderItem { get; }

        public OrderItemAgg(OrderItems orderItem)
        {
            OrderItem = orderItem;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }

        public Menu Menu { get; set; }

        public MenuItem MenuItem { get; set; }

        public Order Order { get; set; }
    }
}