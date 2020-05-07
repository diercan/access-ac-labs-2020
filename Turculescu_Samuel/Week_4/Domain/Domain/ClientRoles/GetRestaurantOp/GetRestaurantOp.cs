using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.ClientRoles.GetRestaurantOp.GetRestaurantResult;

namespace Domain.Domain.ClientRoles.GetRestaurantOp
{
    public class GetRestaurantOp : OpInterpreter<GetRestaurantCmd, GetRestaurantResult.IGetRestaurantResult, Unit>
    {
        public override Task<IGetRestaurantResult> Work(GetRestaurantCmd Op, Unit state)
        {
            return Task.FromResult<IGetRestaurantResult>(new RestaurantFound(new RestaurantAgg(Op.Restaurant)));
        }
    }
}
