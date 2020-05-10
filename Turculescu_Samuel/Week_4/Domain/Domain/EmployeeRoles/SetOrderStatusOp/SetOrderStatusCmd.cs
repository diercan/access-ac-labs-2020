using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.SetOrderStatusOp
{
    public struct SetOrderStatusCmd
    {
        public Order Order { get; }
        public OrderStatus OrderStatus { get; }
        public uint PreparationTimeInMinutes { get; }

        public SetOrderStatusCmd(Order order, OrderStatus orderStatus, uint preparationTimeInMinutes)
        {
            Order = order;
            OrderStatus = orderStatus;
            PreparationTimeInMinutes = preparationTimeInMinutes;
        }
    }
}
