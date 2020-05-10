using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.CreatePaymentRequestOp
{
    public struct CreatePaymentRequestCmd
    {
        public Order Order { get; }
        public PaymentStatus NewPaymentStatus { get; }

        public CreatePaymentRequestCmd(Order order, PaymentStatus newPaymentStatus)
        {
            Order = order;
            NewPaymentStatus = newPaymentStatus;
        }

    }
}
