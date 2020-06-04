﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EfCore
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RestaurantId { get; set; }
        public uint TableNumber { get; set; }
        public DateTime DateTimePlaced { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public TimeSpan PreparationTime { get; set; }
        public string PaymentStatus { get; set; }

        public virtual Client Client { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
