using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetPaymentStatusOp.GetPaymentStatusResult;

namespace Domain.Domain.GetPaymentStatusOp
{
    internal class GetPaymentStatusOp : OpInterpreter<GetPaymentStatusCmd, IGetPaymentStatusResult, Unit>
    {
        public override Task<IGetPaymentStatusResult> Work(GetPaymentStatusCmd Op, Unit state)
        {
            if (Exists(Op.SessionID))
            {
                return Task.FromResult<IGetPaymentStatusResult>(new PaymentStatusGot(AllHardcodedValues.HarcodedVals.Carts[Op.SessionID].Payment));
            }
            else
                return Task.FromResult<IGetPaymentStatusResult>(new NoPaymentStatusGot("The session does not exist"));
        }

        public bool Exists(String sessionID) => AllHardcodedValues.HarcodedVals.Carts.ContainsKey(sessionID);
    }
}