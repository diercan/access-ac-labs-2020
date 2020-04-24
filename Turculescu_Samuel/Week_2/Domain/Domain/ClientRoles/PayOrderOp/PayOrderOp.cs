using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.ClientRoles.PayOrderOp.PayOrderResult;

namespace Domain.Domain.ClientRoles.PayOrderOp
{
    public class PayOrderOp : OpInterpreter<PayOrderCmd, PayOrderResult.IPayOrderResult, Unit>
    {
        public override Task<IPayOrderResult> Work(PayOrderCmd Op, Unit state)
        {
            Op.Client.Order.PaymentStatus = PaymentStatus.Paid;

            return !Exists(Op.Client.CardNumber) ?
                Task.FromResult<IPayOrderResult>(new PayOrderNotSuccessful("Unsuccessful payment!")) :
                Task.FromResult<IPayOrderResult>(new PayOrderSuccessful(Op.Client.Order.PaymentStatus));
        }

        public bool Exists(string CardNumber)
        {
            return true;
        }
    }
}
