using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Models.Restaurant;

namespace Domain.Domain.CreateMenuOp
{
    public class CreateMenuOp : OpInterpreter<CreateMenuCmd, ICreateMenuResult, Unit>
    {
        public override Task<ICreateMenuResult> Work(CreateMenuCmd Op, Unit state)
        {
            if (Exists(Op.Name))
                return Task.FromResult<ICreateMenuResult>(new MenuNotCreated($"There already is a menu with the name {Op.Name}")); // Menu already exists
            else
            {
                (bool CommandIsValid, String ErrorCode) = Op.IsValid();

                if (CommandIsValid)
                {
                    Op.Restaurant.Menus.Add(new Menu(Op.Name, Op.MenuType));
                    // Op.Restaurant.Menu = new Menu(Op.Name, Op.MenuType);
                    return Task.FromResult<ICreateMenuResult>(new MenuCreated(new Menu(Op.Name, Op.MenuType))); // Creates the menu
                }
                else
                {
                    return Task.FromResult<ICreateMenuResult>(new MenuNotCreated(ErrorCode)); // Menu not created for many reasons
                }
            }
        }

        public bool Exists(String menuName/*, Restaurant restaurant*/) => AllHardcodedValues.HarcodedVals.McDonaldsMenus.Contains(menuName) ? true : false;
    }
}