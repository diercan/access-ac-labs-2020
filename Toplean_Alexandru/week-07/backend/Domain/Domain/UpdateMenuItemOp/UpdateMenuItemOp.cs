using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.UpdateMenuItemOp.UpdateMenuItemResult;

namespace Domain.Domain.UpdateMenuItemOp
{
    public class UpdateMenuItemOp : OpInterpreter<UpdateMenuItemCmd, IUpdateMenuItemResult, Unit>
    {
        public override Task<IUpdateMenuItemResult> Work(UpdateMenuItemCmd Op, Unit state)
        {
            return Task.FromResult<IUpdateMenuItemResult>(new MenuItemUpdated(Op.MenuItem));
        }
    }
}