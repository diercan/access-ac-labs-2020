using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.EmployeeRoles.GetOrderStatusOp
{
    [AsChoice]
    public static partial class GetOrderStatusResult
    {        
        public interface IGetOrderStatusResult { }

        public class GetOrderStatus : IGetOrderStatusResult
        {
            public OrderStatus OrderStatus { get; }

            public GetOrderStatus(OrderStatus orderStatus)
            {
                OrderStatus = orderStatus;
            }
        }
    }
}
