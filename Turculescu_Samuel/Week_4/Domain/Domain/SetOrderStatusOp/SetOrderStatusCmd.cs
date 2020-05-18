using Domain.Models;
using LanguageExt.UnitsOfMeasure;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SetOrderStatusOp
{
    public struct SetOrderStatusCmd
    {
        public Order Order { get; }
        public string OrderStatus { get; }
        public TimeSpan PreparationTime { get; }

        public SetOrderStatusCmd(Order order, string orderStatus, TimeSpan preparationTime)
        {
            Order = order;
            OrderStatus = orderStatus;
            PreparationTime = preparationTime;
        }
    }
}
