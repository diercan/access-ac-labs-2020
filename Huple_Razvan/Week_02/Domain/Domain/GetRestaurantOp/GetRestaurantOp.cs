using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;

namespace Domain.Domain.GetRestaurantOp
{

    public class GetRestaurantOp : OpInterpreter<GetRestaurantCmd, GetRestaurantResult.IGetRestaurantResult, Unit>
    {
        public override Task<IGetRestaurantResult> Work(GetRestaurantCmd Op, Unit state)
        {
            //validate
            if (Op.restaurants.Contains(Op.Restaurant))
                return Task.FromResult<IGetRestaurantResult>((IGetRestaurantResult)new RestaurantFound(Op.Restaurant));
            else
                return Task.FromResult<IGetRestaurantResult>((IGetRestaurantResult)new RestaurantNotFound("not found"));
        }
    }
}
