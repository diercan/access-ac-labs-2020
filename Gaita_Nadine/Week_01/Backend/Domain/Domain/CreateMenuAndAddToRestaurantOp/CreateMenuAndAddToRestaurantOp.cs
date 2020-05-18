using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.CreateMenuOp.CreateMenuAndAddToRestaurantResult;

namespace Domain.Domain.CreateMenuOp
{
    public class CreateMenuAndAddToRestaurantOp : OpInterpreter<CreateMenuAndAddToRestaurantCmd, ICreateMenuResult, Unit>
    {
        public override Task<ICreateMenuResult> Work(CreateMenuAndAddToRestaurantCmd Op, Unit state)
        {
            Menu menu = new Menu(Op.Name, Op.MenuType);

            Op.Restaurant.Menus.Add(menu);

            return Task.FromResult((ICreateMenuResult)new MenuCreated(menu));
        }
    }
}
