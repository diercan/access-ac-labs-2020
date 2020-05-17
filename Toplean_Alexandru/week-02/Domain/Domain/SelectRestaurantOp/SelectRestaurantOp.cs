using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;
using static Domain.Models.Restaurant;

namespace Domain.Domain.SelectRestaurantOp
{
    public class SelectRestaurantOp : OpInterpreter<SelectRestaurantCmd, ISelectRestaurantResult, Unit>
    {
        public override Task<ISelectRestaurantResult> Work(SelectRestaurantCmd Op, Unit state)
        {
            if (!Exists(Op.RestaurantName))
            {
                return Task.FromResult<ISelectRestaurantResult>(new RestaurantNotSelected($"There is no restaurant with the name {Op.RestaurantName}"));
            }
            else
            {
                (bool CommandIsValid, String Error) = Op.IsValid();
                if (CommandIsValid)
                {
                    Restaurant restaurant = AllHardcodedValues.HarcodedVals.RestaurantList.FirstOrDefault(v => v.Name == Op.RestaurantName);
                    return Task.FromResult<ISelectRestaurantResult>(new RestaurantSelected(restaurant));
                }
                else
                {
                    return Task.FromResult<ISelectRestaurantResult>(new RestaurantNotSelected(Error));
                }
            }
        }

        public bool Exists(String name) => AllHardcodedValues.HarcodedVals.Restaurants.Any(r => r == name);
    }
}