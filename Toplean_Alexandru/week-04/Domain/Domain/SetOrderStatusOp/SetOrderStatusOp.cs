using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.SetOrderStatusOp.SetOrderStatusResult;

namespace Domain.Domain.SetOrderStatusOp
{
    internal class SetOrderStatusOp : OpInterpreter<SetOrderStatusCmd, ISetOrderStatusResult, Unit>
    {
        public override Task<ISetOrderStatusResult> Work(SetOrderStatusCmd Op, Unit state)
        {
            if (Op.IsValid())
            {
                // Sets the order status of the cart to the new status
                Op.ClientAgg.Cart.Status = Op.CartStatus;
                return Task.FromResult<ISetOrderStatusResult>(new OrderStatusSet());
            }
            else // Cart doesn't exist
                return Task.FromResult<ISetOrderStatusResult>(new OrderStatusNotSet("The cart does not exist"));
        }
    }
}