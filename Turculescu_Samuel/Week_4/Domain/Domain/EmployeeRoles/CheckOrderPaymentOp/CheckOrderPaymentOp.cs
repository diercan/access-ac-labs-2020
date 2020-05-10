using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.EmployeeRoles.CheckOrderPaymentOp.CheckOrderPaymentResult;

namespace Domain.Domain.EmployeeRoles.CheckOrderPaymentOp
{
    public class CheckOrderPaymentOp : OpInterpreter<CheckOrderPaymentCmd, CheckOrderPaymentResult.ICheckOrderPaymentResult, Unit>
    {
        public override Task<ICheckOrderPaymentResult> Work(CheckOrderPaymentCmd Op, Unit state)
        {
            return Task.FromResult<ICheckOrderPaymentResult>(new CheckOrderPaymentStatus(Op.Order.PaymentStatus));
        }
    }
}
