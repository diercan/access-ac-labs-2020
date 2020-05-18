using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetMenuItemOp.GetMenuItemResult;

namespace Domain.Domain.GetMenuItemOp
{
    class GetMenuItemOp : OpInterpreter<GetMenuItemCmd, GetMenuItemResult.IGetMenuItemResult, Unit>
    {
        public override Task<IGetMenuItemResult> Work(GetMenuItemCmd Op, Unit state)
        {
            return (Op.MenuItem is null) ?
                Task.FromResult<IGetMenuItemResult>(new MenuItemNotFound("MenuItem not found!")) :
                Task.FromResult<IGetMenuItemResult>(new MenuItemFound(new MenuItemAgg(Op.MenuItem)));
        }
    }
}

