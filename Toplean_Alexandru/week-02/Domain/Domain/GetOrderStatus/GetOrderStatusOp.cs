using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetOrderStatus.GetOrderStatusResult;

namespace Domain.Domain.GetOrderStatus
{
    internal class GetOrderStatusOp : OpInterpreter<GetOrderStatusCmd, IGetOrderStatusResult, Unit>
    {
        public override Task<IGetOrderStatusResult> Work(GetOrderStatusCmd Op, Unit state)
        {
            if (Op.IsValid())
            {
                // Successfully returns the order/cart status
                return Task.FromResult<IGetOrderStatusResult>(new OrderGot(AllHardcodedValues.HarcodedVals.Carts[Op.SessionID].Status));
            }
            else
            {
                // The SessionID does not exist in the sessions Dictionary(AllHardCodedValues.HardcodedVals.Carts)
                return Task.FromResult<IGetOrderStatusResult>(new NoOrderGot("Session has expired"));
            }
        }
    }
}