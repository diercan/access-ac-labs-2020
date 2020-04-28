using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Domain.GetMenuItemOp.GetMenuItemResult;
using Domain.Models;

namespace Domain.Domain.GetMenuItemOp
{
    internal class GetMenuItemOp : OpInterpreter<GetMenuItemCmd, IGetMenuItemResult, Unit>
    {
        public override Task<IGetMenuItemResult> Work(GetMenuItemCmd Op, Unit state)
        {
            if (Exists(Op.Restaurant, Op.Menu, Op.MenuItemName))
            {
                (bool CommandIsValid, String Error) = Op.IsValid();
                if (CommandIsValid)
                    return Task.FromResult<IGetMenuItemResult>(new MenuItemGot(AllHardcodedValues.HarcodedVals.RestaurantList.FirstOrDefault(r => r == Op.Restaurant).Menus.FirstOrDefault(m => m == Op.Menu).Items.FirstOrDefault(mi => mi.Name == Op.MenuItemName)));
                else
                    return Task.FromResult<IGetMenuItemResult>(new NoMenuItemGot(Error));
            }
            else
                return Task.FromResult<IGetMenuItemResult>(new NoMenuItemGot("The Menu Item does not exist"));
        }

        // public bool Exists(Restaurant restaurant, String name) => AllHardcodedValues.HarcodedVals.RestaurantList.FirstOrDefault(r => r == restaurant).Menus.ForAll(m => m.Items.Any(mi => mi.Name == name));
        public bool Exists(Restaurant restaurant, Menu menu, String name) => AllHardcodedValues.HarcodedVals.RestaurantList.FirstOrDefault(r => r == restaurant).Menus.FirstOrDefault(m => m == menu).Items.Any(mi => mi.Name == name);
    }
}