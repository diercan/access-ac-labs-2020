using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;

namespace Domain.Domain.CreateMenuItemOp
{
    class CreateMenuItemOp : OpInterpreter<CreateMenuItemCmd, ICreateMenuItemResult, Unit> 
    {
        public override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            if (Op.Price > 30)
                return Task.FromResult((ICreateMenuItemResult)new MenuItemNotCreated("price too high!"));
            else
            {
                Op.Menu.MenuItem = new MenuItem(Op.Name, Op.Price);
                return Task.FromResult((ICreateMenuItemResult)new MenuItemCreated(Op.Menu.MenuItem));
            }
        }
    }
}
