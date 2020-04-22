using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Domain.GetOrdersOp.GetOrdersResult;
using Domain.Models;

namespace Domain.Domain.GetOrdersOp
{
    public class GetOrdersOp : OpInterpreter<GetOrdersCmd, IGetOrdersResult, Unit>
    {
        public override Task<IGetOrdersResult> Work(GetOrdersCmd Op, Unit state)
        {
            if (Exists(Op.Restaurant))
            {
                if (Op.IsValid())
                {
                    // Gets the orders
                    return Task.FromResult<IGetOrdersResult>(new OrdersGot(Op.Restaurant.Orders));
                }
                else
                {
                    // No orders in the list
                    return Task.FromResult<IGetOrdersResult>(new NoOrdersGot("The restaurant does not have any orders at the moment"));
                }
            }
            else
            {
                // Restaurant doesn't exist
                return Task.FromResult<IGetOrdersResult>(new NoOrdersGot("The restaurant does not exist"));
            }
        }

        public bool Exists(Restaurant restaurant) => AllHardcodedValues.HarcodedVals.RestaurantList.Any(r => r == restaurant);
    }
}