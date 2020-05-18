using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreatePaymentRequestOp.CreatePaymentRequestResult;


namespace Domain.Domain.CreatePaymentRequestOp
{
    public class CreatePaymentRequestOp : OpInterpreter<CreatePaymentRequestCmd, CreatePaymentRequestResult.ICreatePaymentRequestResult, Unit>
    {
        public override Task<ICreatePaymentRequestResult> Work(CreatePaymentRequestCmd Op, Unit state)
        {
            if (IsPaid(Op.Order.PaymentStatus))
            {
                return Task.FromResult<ICreatePaymentRequestResult>(new PaymentOrderStatus("Order is already paid!"));
            }
            else
            {
                Op.Order.PaymentStatus = "AwaitingPayment";
                return Task.FromResult<ICreatePaymentRequestResult>(new PaymentOrderStatus(Op.Order.PaymentStatus));
            }                
        }

        public bool IsPaid(string currentPaymentStatus)
        {
            if (currentPaymentStatus == "Paid")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
