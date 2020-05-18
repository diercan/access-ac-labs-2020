using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Domain.Models
{
    public class OrderItemAgg
    {      
        public OrderItem OrderItem { get; set; }

        public OrderItemAgg(OrderItem orderItem)
        {
            OrderItem = orderItem;
        }
    }
}
