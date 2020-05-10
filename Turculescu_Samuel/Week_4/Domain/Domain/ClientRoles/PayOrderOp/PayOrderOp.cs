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
            if(!Exists(Op.Client.Client.CardNumber))
            {
                return Task.FromResult<IPayOrderResult>(new PayOrderStatus("Unsuccessful payment! Please try again!"));
            }
            else
            {
                Op.Order.PaymentStatus = PaymentStatus.Paid;
                Op.Client.OrdersPlaced.Add(Op.Order);
                return Task.FromResult<IPayOrderResult>(new PayOrderStatus($"Your order: {Op.Order.OrderId} is paid. Thank you!"));

            }                     
        }

        public bool Exists(string CardNumber)
        {
            if (CardNumber != null)
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
