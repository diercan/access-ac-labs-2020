using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;

namespace Domain.Domain.CreateMenuOp
{
    public class CreateMenuOp : OpInterpreter<CreateMenuCmd, ICreateMenuResult, Unit>
    {
        public override Task<ICreateMenuResult> Work(CreateMenuCmd Op, Unit state)
        {
            var menu = new Menu(Op.Name, Op.MenuType);
            Op.Restaurant.Menu.Add(menu);
            return Task.FromResult((ICreateMenuResult)new MenuCreated(Op.Restaurant.Menu));
        }
    }
}
