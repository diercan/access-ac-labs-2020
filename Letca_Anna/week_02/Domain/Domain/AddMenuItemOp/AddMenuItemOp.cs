
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.AddMenuItemOp.AddMenuItemResult;

namespace Domain.Domain.AddMenuItemOp
{
    class AddMenuItemOp : OpInterpreter<AddMenuItemCmd, IAddMenuItemResult, Unit>
    {
        public override Task<IAddMenuItemResult> Work(AddMenuItemCmd Op, Unit state)
        {
            return Exists(Op.MenuItem, Op.Menu) ?
                 Task.FromResult((IAddMenuItemResult)new MenuItemNotAdded($"<{Op.MenuItem.Name}> already exists in <{Op.Menu.Name}> menu!", Op.Menu)) :
                 Task.FromResult((IAddMenuItemResult)new MenuItemAdded(Op.MenuItem,Op.Menu));
        }

        public bool Exists(MenuItem menuItem, Menu menu)
        {
            return menu.MenuItems.Contains(menuItem);
        }
    }
}
