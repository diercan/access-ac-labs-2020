using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Domain.SetMenuAvalabilityOp.SetMenuAvalabilityResult;

namespace Domain.Domain.SetMenuAvalabilityOp
{
    public class SetMenuAvalabilityOp : OpInterpreter<SetMenuAvalabilityCmd, ISetMenuAvalabilityResult, Unit>
    {
        public override Task<ISetMenuAvalabilityResult> Work(SetMenuAvalabilityCmd Op, Unit state)
        {
            if (RestaurantExists(Op.Restaurant))
            {
                if (MenuExists(Op.Restaurant, Op.Menu))
                {
                    (bool CommandIsValid, String Error) = Op.IsValid();
                    if (CommandIsValid)
                    {
                        // If there is no existent key with the specified time period, stored in Op.Hour, it will create that key with an empty Menu List
                        if (!AllHardcodedValues.HarcodedVals.SpecialMenus.ContainsKey(Op.Hour))
                        {
                            AllHardcodedValues.HarcodedVals.SpecialMenus.Add(Op.Hour, new List<Menu>());
                        }
                        // Setting the menu to a special or regular menu
                        Op.Menu.MenuVisibilityTypes = Op.MenuVisibilityTypes;

                        // If the menu will be a special menu it will be added in the List<Menu>
                        if (Op.MenuVisibilityTypes == MenuVisibilityTypes.SpecialMenu)
                            AllHardcodedValues.HarcodedVals.SpecialMenus[Op.Hour].Add(Op.Menu);
                        else // If the menu was special and  now is set to regular, it will be removed from the SpecialMenus List
                            AllHardcodedValues.HarcodedVals.SpecialMenus[Op.Hour].Remove(Op.Menu);

                        return Task.FromResult<ISetMenuAvalabilityResult>(new MenuAvalabilitySet());
                    }
                    else
                        return Task.FromResult<ISetMenuAvalabilityResult>(new MenuAvalabilityNotSet(Error));
                }
                else // Menu doesn't exist
                    return Task.FromResult<ISetMenuAvalabilityResult>(new MenuAvalabilityNotSet($"The menu {Op.Menu.Name} does not exist"));
            }
            else // Restaurant doesn't exist
                return Task.FromResult<ISetMenuAvalabilityResult>(new MenuAvalabilityNotSet($"The restaurant does not exist"));
        }

        public bool RestaurantExists(Restaurant restaurant) => AllHardcodedValues.HarcodedVals.RestaurantList.Any(r => r == restaurant);

        public bool MenuExists(Restaurant restaurant, Menu menu) =>
            AllHardcodedValues.HarcodedVals.RestaurantList.FirstOrDefault(r => r == restaurant).Menus.Any(m => m == menu);
    }
}