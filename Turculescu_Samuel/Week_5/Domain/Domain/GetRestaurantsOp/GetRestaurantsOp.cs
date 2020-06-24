using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetRestaurantsOp.GetRestaurantsResult;

namespace Domain.Domain.GetRestaurantsOp
{
    public class GetRestaurantsOp : OpInterpreter<GetRestaurantsCmd, IGetRestaurantsResult, Unit>
    {
        public override Task<IGetRestaurantsResult> Work(GetRestaurantsCmd Op, Unit state)
        {
            return (Op.Restaurants is null) ?
                Task.FromResult<IGetRestaurantsResult>(new RestaurantsNotFound("There is no restaurant")) :
                Task.FromResult<IGetRestaurantsResult>(new RestaurantsFound(Op.Restaurants));
        }
    }
}
