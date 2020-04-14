using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Order
    {
        public int IdOrder { get; }
        public Order(int idOrder)
        {
            IdOrder = idOrder;
        }
    }
}
