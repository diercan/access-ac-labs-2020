using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetOrdersOp
{
    public struct GetOrdersCmd
    {
        public List<Order> Orders { get; }
        public Restaurant Restaurant { get; }

        public GetOrdersCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
            Orders = restaurant.Orders;
        }

        // Will return false if there are no orders or the Orders list is not initialized
        public bool IsValid()
        {
            if (Orders == null)
                return false;

            if (Orders.Count == 0)
                return false;

            return true;
        }
    }
}