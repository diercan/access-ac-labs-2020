using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.PlaceOrderOp.PlaceOrderResult;

namespace Domain.Domain.PlaceOrderOp
{
    internal class PlaceOrderOp : OpInterpreter<PlaceOrderCmd, IPlaceOrderResult, Unit>
    {
        public override Task<IPlaceOrderResult> Work(PlaceOrderCmd Op, Unit state)
        {
            (bool CommandIsValid, String Error) = Op.IsValid();
            if (CommandIsValid)
            {
                AllHardcodedValues.HarcodedVals.Carts[Op.Client.SessionID].Status = Models.Cart.CartStatus.CartSubmitted;
                return Task.FromResult<IPlaceOrderResult>(new OrderPlaced());
            }
            else
                return Task.FromResult<IPlaceOrderResult>(new OrderNotPlaced(Error));
        }
    }
}