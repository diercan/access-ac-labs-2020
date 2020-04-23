using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Order
    {
        public uint OrderId { get; }
        
        public uint PreparationTimeInMinutes {get; set;}    // Preparation time for a MenuItem

        public List<CartItem> OrderItems { get; set; }

        public Order(uint orderId)
        {
            OrderId = orderId;
        }
    }
}
