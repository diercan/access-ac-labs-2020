
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
    public class AddMenuItemOp : OpInterpreter<AddMenuItemCmd, IAddMenuItemResult, Unit>
    {
        public override Task<IAddMenuItemResult> Work(AddMenuItemCmd Op, Unit state)
        {

            var (valid, validationMessage) = Op.Validate();


            if (!valid)
                return Task.FromResult((IAddMenuItemResult)new NullItemNotAdded(validationMessage));

            return Task.FromResult((IAddMenuItemResult)new MenuItemAdded(Op.MenuItem, Op.Menu));
        }

        public bool Exists(MenuItem menuItem, Menu menu)
        {
            return menu.MenuItems.Contains(menuItem);
        }
    }
}
