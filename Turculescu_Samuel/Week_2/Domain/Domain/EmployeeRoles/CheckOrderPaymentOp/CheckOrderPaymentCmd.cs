using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.CheckOrderPaymentOp
{
    public struct CheckOrderPaymentCmd
    {
        public Order Order { get; }

        public CheckOrderPaymentCmd(Order order)
        {
            Order = order;
        }
    }
}
