using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;

namespace Domain.Domain.GetRestaurantOp
{
    public class GetRestaurantOp : OpInterpreter<GetRestaurantCmd, IGetRestaurantResult, Unit>
    {
        public override Task<IGetRestaurantResult> Work(GetRestaurantCmd Op, Unit state)
        {

            if (!Storage.RestaurantCollection.ContainsKey(Op.Name))
                return Task.FromResult<IGetRestaurantResult>(new RestaurantNotFound($"restaurant with name {Op.Name} not found!"));

            return Task.FromResult<IGetRestaurantResult>(new RestaurantFound(Storage.RestaurantCollection[Op.Name]));
        }
    }
}
