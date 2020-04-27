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
            /*Restaurant r = new Restaurant(Op.Name);
            if (Op.restaurants.Contains(r))
                return Task.FromResult<IGetRestaurantResult>((IGetRestaurantResult)new RestaurantFound(r));
            else
                return Task.FromResult<IGetRestaurantResult>((IGetRestaurantResult)new RestaurantNotFound("list is empty"));*/
                foreach(var r in Op.restaurants)
                    if(r.Name.Equals(Op.Name))
                        return Task.FromResult<IGetRestaurantResult>((IGetRestaurantResult)new RestaurantFound(r));
            return Task.FromResult<IGetRestaurantResult>((IGetRestaurantResult)new RestaurantNotFound("list is empty"));
        }
    }
}
