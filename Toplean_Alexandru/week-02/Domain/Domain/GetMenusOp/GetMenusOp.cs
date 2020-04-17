using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetMenusOp.GetMenusResult;

namespace Domain.Domain.GetMenusOp
{
    internal class GetMenusOp : OpInterpreter<GetMenusCmd, IGetMenusResult, Unit>
    {
        public override Task<IGetMenusResult> Work(GetMenusCmd Op, Unit state)
        {
            if (Exists(Op.Restaurant))
            {
                if (Op.IsValid())
                {
                    // Menus are successfully selected
                    return Task.FromResult<IGetMenusResult>(new MenusGot(Op.Menus));
                }
                else
                {
                    // No menus were selected, Menu List of the restaurant was null
                    return Task.FromResult<IGetMenusResult>(new NoMenusGot($"Restaurant {Op.Restaurant.Name} has no menus"));
                }
            }
            else
            {
                // No menus selected. There was no restaurant with that name
                return Task.FromResult<IGetMenusResult>(new NoMenusGot($"No restaurant with the name {Op.Restaurant.Name} exists!"));
            }
        }

        public bool Exists(Restaurant restaurant) => AllHardcodedValues.HarcodedVals.RestaurantList.Contains(restaurant);
    }
}