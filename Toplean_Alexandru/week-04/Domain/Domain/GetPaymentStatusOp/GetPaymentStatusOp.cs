using Domain.Models;
using EarlyPay.Primitives.Mocking;
using Infrastructure.Free;
using LanguageExt;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetPaymentStatusOp.GetPaymentStatusResult;

namespace Domain.Domain.GetPaymentStatusOp
{
    public partial class GetPaymentStatusOp : OpInterpreter<GetPaymentStatusCmd, IGetPaymentStatusResult, Unit>
    {
        public async override Task<IGetPaymentStatusResult> Work(GetPaymentStatusCmd Op, Unit state)
        {
            if (Exists(Op.Order))
            {
                var (CommandIsValid, ErrorMessage) = Op.IsValid();
                if (CommandIsValid)
                {
                    return new PaymentStatusGot(Op.Order.PaymentStatus);
                }
                else
                    return new NoPaymentStatusGot(ErrorMessage);
            }
            else
                return new NoPaymentStatusGot("The session does not exist");
        }

       

        public bool Exists(Order client) => client != null;
    }
}