
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.AddMenuItemOp.AddMenuItemResult;

namespace Domain.Domain.AddMenuItemOp
{
    class AddMenuItemOp : OpInterpreter<AddMenuItemCmd, IAddMenuItemResult, Unit>
    {
        public override Task<IAddMenuItemResult> Work(AddMenuItemCmd Op, Unit state)
        {
            return Exists(Op.MenuItem.Name) ?
                 Task.FromResult((IAddMenuItemResult)new MenuItemNotAdded("Menu item already exists in this menu!")) :
                 Task.FromResult((IAddMenuItemResult)new MenuItemAdded(Op.MenuItem,Op.Menu));
        }

        public bool Exists(string name)
        {
            return false;
        }
    }
}
