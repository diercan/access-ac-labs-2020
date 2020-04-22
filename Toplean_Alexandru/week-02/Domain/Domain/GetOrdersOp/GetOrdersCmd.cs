using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetOrdersOp
{
    public struct GetOrdersCmd
    {
        public Restaurant Restaurant { get; }

        public GetOrdersCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }

        // Will return false if there are no orders or the Orders list is not initialized
        public bool IsValid()
        {
            return true;
        }
    }
}