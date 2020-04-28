using System.Threading.Tasks;
using LanguageExt;
using System;
using System.Data.SqlTypes;
using Infrastructure.Free;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;

namespace Domain.Domain.GetRestaurantOp
{
    public class GetRestaurantOp : OpInterpreter<GetRestaurantCmd,GetRestaurantResult.IGetRestaurantResult,Unit>
    {
        public override Task<IGetRestaurantResult> Work(GetRestaurantCmd Op, Unit state)
        {
            if (Op.Name == "mcdonalds")
                return Task.FromResult<IGetRestaurantResult>(new RestaurantFound(Op.Name));
            else
                return Task.FromResult<IGetRestaurantResult>(new RestaurantNotFound("nu-i aci"));
        }
    }
}