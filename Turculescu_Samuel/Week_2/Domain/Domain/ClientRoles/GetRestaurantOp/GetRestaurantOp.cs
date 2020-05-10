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
        private List<Restaurant>.Enumerator r = Storage.RestaurantsList.GetEnumerator();    // r is enumerator for RestaurantsList

        public override Task<IGetRestaurantResult> Work(GetRestaurantCmd Op, Unit state)
        {

            // Validate

            return !Exists(Op.Name) ?
                Task.FromResult<IGetRestaurantResult>(new GetRestaurantNotSuccessful($"There is no restaurant with this name: {Op.Name}!")) : 
                Task.FromResult<IGetRestaurantResult>(new GetRestaurantSuccessful(r.Current));
        }

        // Verify if restaurant selected is opened or not
        public bool Exists(string restaurantName)
        {
            while (r.MoveNext())
            {
                if(restaurantName == r.Current.Name)
                {
                    return true;
                }
            }
            return false;            
        }
    }
}
