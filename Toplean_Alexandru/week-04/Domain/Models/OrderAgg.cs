using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class OrderAgg
    {
        public Order Order { get; }

        public OrderAgg(Order order)
        {
            Order = order;
        }
    }
}