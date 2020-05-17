using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Entities.Base;

namespace Database.Entities
{
    [Table("Order")]
    public class OrderEntity : BaseEntity
    {
        // public User Custotomer { get; set; }
        
        [DefaultValue(OrderStatus.Placed)]
        public OrderStatus Status { get; set; }
        
        public List<OrderItemEntity> Items { get; set; }
    }

    [Flags]
    public enum OrderStatus
    {
        Placed,
        Finished,
        Delivered,
        Paid = 4
    }
}
