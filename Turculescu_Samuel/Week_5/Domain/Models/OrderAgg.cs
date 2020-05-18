using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class OrderAgg
    {
        public Order Order { get; set; }

        public OrderAgg(Order order)
        {
            Order = order;
        }
    }
}
