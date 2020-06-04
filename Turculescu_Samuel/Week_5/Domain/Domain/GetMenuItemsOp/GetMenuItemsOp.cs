using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetMenuItemsOp.GetMenuItemsResult;

namespace Domain.Domain.GetMenuItemsOp
{
    class GetMenuItemsOp : OpInterpreter<GetMenuItemsCmd, GetMenuItemsResult.IGetMenuItemsResult, Unit>
    {
        public override Task<IGetMenuItemsResult> Work(GetMenuItemsCmd Op, Unit state)
        {
            return (Op.MenuItems is null) ?
                Task.FromResult<IGetMenuItemsResult>(new MenuItemsNotFound("There is no menu item in this menu!")) :
                Task.FromResult<IGetMenuItemsResult>(new MenuItemsFound(Op.MenuItems));
        }
    }
}

