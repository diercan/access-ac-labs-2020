using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.PlaceOrder.PlaceOrderResult;

namespace Domain.Domain.PlaceOrder
{
    public class PlaceOrderOp : OpInterpreter<PlaceOrderCmd, IPlaceOrderResult, Unit>
    {
        public override System.Threading.Tasks.Task<IPlaceOrderResult> Work(PlaceOrderCmd Op, Unit state)
        {
            return Task.FromResult((IPlaceOrderResult)new OrderPlaced(Op.Order));
        }
    }
}
