using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.EmployeeRoles.CreatePaymentRequestOp.CreatePaymentRequestResult;


namespace Domain.Domain.EmployeeRoles.CreatePaymentRequestOp
{
    public class CreatePaymentRequestOp : OpInterpreter<CreatePaymentRequestCmd, CreatePaymentRequestResult.ICreatePaymentRequestResult, Unit>
    {
        public override Task<ICreatePaymentRequestResult> Work(CreatePaymentRequestCmd Op, Unit state)
        {
            if (IsPaid(Op.Order.PaymentStatus))
            {
                return Task.FromResult<ICreatePaymentRequestResult>(new PaymentRequestNotCreated("Order is already paid!"));
            }
            else
            {
                Op.Order.PaymentStatus = Op.NewPaymentStatus;
                return Task.FromResult<ICreatePaymentRequestResult>(new PaymentRequestCreated(Op.Order.PaymentStatus));
            }                
        }

        public bool IsPaid(PaymentStatus currentPaymentStatus)
        {
            if (currentPaymentStatus == PaymentStatus.Paid)
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
