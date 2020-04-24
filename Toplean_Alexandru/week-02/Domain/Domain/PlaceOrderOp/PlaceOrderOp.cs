using Infrastructure.Free;
using LanguageExt;
using System.Linq;
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
            if (SessionExists(SessionID: Op.Client.SessionID))
            {
                if (CartExists(Op.Client.SessionID))
                {
                    (bool CommandIsValid, String Error) = Op.IsValid();
                    if (CommandIsValid)
                    {
                        // Placing the order and modifying the cart status to submitted
                        AllHardcodedValues.HarcodedVals.Carts[Op.Client.SessionID].Status = Models.Cart.CartStatus.CartSubmitted;
                        AllHardcodedValues.HarcodedVals.RestaurantList.FirstOrDefault(r => r == Op.Restaurant).Orders.Add(new Models.Order(0, Op.Client.Table, Op.Client.Cart, null, 999));
                        return Task.FromResult<IPlaceOrderResult>(new OrderPlaced());
                    }
                    else
                        return Task.FromResult<IPlaceOrderResult>(new OrderNotPlaced(Error)); // Invalid command return reason
                }
                else
                    return Task.FromResult<IPlaceOrderResult>(new OrderNotPlaced("The cart no longer exists")); // Cart no longer  exists
            }
            else
                return Task.FromResult<IPlaceOrderResult>(new OrderNotPlaced("The session does not exist anymore")); // Session expired
        }

        public bool SessionExists(String SessionID) => AllHardcodedValues.HarcodedVals.Carts.ContainsKey(SessionID);

        public bool CartExists(String SessionID) => AllHardcodedValues.HarcodedVals.Carts[SessionID] != null;
    }
}