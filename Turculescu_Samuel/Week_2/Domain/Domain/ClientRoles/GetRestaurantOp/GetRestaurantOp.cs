using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.ClientRoles.GetRestaurantOp.GetRestaurantResult;

namespace Domain.Domain.ClientRoles.GetRestaurantOp
{
    public class GetRestaurantOp : OpInterpreter<GetRestaurantCmd, GetRestaurantResult.IGetRestaurantResult, Unit>
    {
        public override Task<IGetRestaurantResult> Work(GetRestaurantCmd Op, Unit state)
        {
            Op.Client.GoToRestaurant = Op.Restaurant;   // Link restaurant selected by client 

            // Validate

            return !Opened(Op.Restaurant) ?
                Task.FromResult<IGetRestaurantResult>(new RestaurantNotGotten("Restaurant is closed!")) : 
                Task.FromResult<IGetRestaurantResult>(new RestaurantGotten(Op.Client.GoToRestaurant));

        }

        // Verify if restaurant selected is opened or not
        public bool Opened(Restaurant restaurant)
        {
            return true;
        }
    }
}
