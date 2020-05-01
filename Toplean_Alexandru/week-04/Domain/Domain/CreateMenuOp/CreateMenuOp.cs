using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;

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
                    Menu menuEntity = new Menu(Op.RestaurantId, Op.Name, Op.MenuTypes.ToString(), false, null);
                    MenuAgg menu = new MenuAgg(menuEntity);
                    Op.Restaurant.Menu.Add(menuEntity);
                    //Op.Restaurant.Menu.Add(menu);

                    return Task.FromResult<ICreateMenuResult>(new MenuCreated(menu)); // Creates the menu
                }
                else
                {
                    return Task.FromResult<ICreateMenuResult>(new MenuNotCreated(ErrorCode)); // Menu not created for many reasons
                }
            }
        }

        public bool Exists(String name) => false;
    }
}