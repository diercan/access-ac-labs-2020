using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.DeleteMenuItemOp.DeleteMenuItemResult;

namespace Domain.Domain.DeleteMenuItemOp
{
    public class DeleteMenuItemOp : OpInterpreter<DeleteMenuItemCmd, IDeleteMenuItemResult, Unit>
    {
        public override Task<IDeleteMenuItemResult> Work(DeleteMenuItemCmd Op, Unit state)
        {
            return Task.FromResult<IDeleteMenuItemResult>(new MenuItemDeleted(Op.MenuItem));
        }
    }
}