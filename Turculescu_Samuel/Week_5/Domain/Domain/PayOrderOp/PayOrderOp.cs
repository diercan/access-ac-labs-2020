using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.PayOrderOp.PayOrderResult;

namespace Domain.Domain.PayOrderOp
{
    public class PayOrderOp : OpInterpreter<PayOrderCmd, PayOrderResult.IPayOrderResult, Unit>
    {
        public override Task<IPayOrderResult> Work(PayOrderCmd Op, Unit state)
        {          
            if(!Exists(Op.Client.CardNumber))
            {
                return Task.FromResult<IPayOrderResult>(new OrderNotPaid("Unsuccessful payment! Please try again!"));
            }
            else
            {
                Op.Order.PaymentStatus = "Paid";                
                return Task.FromResult<IPayOrderResult>(new OrderPaid(($"Your order: {Op.Order.Id} is paid. Thank you!"), new OrderAgg(Op.Order)));

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
