using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;

namespace Domain.Domain.GetRestaurantOp
{
    public class GetRestaurantOp : OpInterpreter<GetRestaurantCmd, IGetRestaurantResult, Unit>
    {
        public override System.Threading.Tasks.Task<IGetRestaurantResult> Work(GetRestaurantCmd Op, Unit state)
        {
            return Task.FromResult<IGetRestaurantResult>(new RestaurantFound(new Restaurant(Op.Restaurant.Name)));
        }
    }
}
