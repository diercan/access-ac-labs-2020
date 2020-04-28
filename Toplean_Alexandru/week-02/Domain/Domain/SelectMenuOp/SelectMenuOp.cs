using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Domain.SelectMenuOp.SelectMenuResult;

namespace Domain.Domain.SelectMenuOp
{
    public class SelectMenuOp : OpInterpreter<SelectMenuCmd, ISelectMenuResult, Unit>
    {
        public override Task<ISelectMenuResult> Work(SelectMenuCmd Op, Unit state)
        {
            if (MenuExists(Op.Restaurant, Op.MenuName))
            {
                (bool CommandIsValid, String Error) = Op.IsValid();
                return CommandIsValid ?
                    Task.FromResult<ISelectMenuResult>(new MenuSelected(AllHardcodedValues.HarcodedVals.RestaurantList.FirstOrDefault(r => r == Op.Restaurant).Menus.FirstOrDefault(m => m.Name == Op.MenuName))) :
                    Task.FromResult<ISelectMenuResult>(new MenuNotSelected(Error));
            }
            else
                return Task.FromResult<ISelectMenuResult>(new MenuNotSelected("The menu does not exist"));
        }

        public bool MenuExists(Restaurant restaurant, String menuName) => AllHardcodedValues.HarcodedVals.RestaurantList.FirstOrDefault(r => r == restaurant).Menus.Any(m => m.Name == menuName);
    }
}