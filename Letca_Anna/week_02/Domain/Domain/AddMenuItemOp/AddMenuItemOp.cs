
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

            var (valid, validationResults) = Op.Validate();

            var menuIsInvalid = !valid ? validationResults.Exists(x => x.MemberNames.Exists(x => x.Equals("Menu"))) : false;
            var itemIsInvalid = !valid ? validationResults.Exists(x => x.MemberNames.Exists(x => x.Equals("MenuItem"))) : false;

            if (menuIsInvalid)
                return Task.FromResult((IAddMenuItemResult)new MenuItemNotAddedToNullMenu($"{Op.MenuItem.Name} cant be added to NULL menu")) ;
            else if (itemIsInvalid)
                return Task.FromResult((IAddMenuItemResult)new NullItemNotAdded("NULL menu item cant be added to menu"));

            return Task.FromResult((IAddMenuItemResult)new MenuItemAdded(Op.MenuItem, Op.Menu));
        }

        public bool Exists(MenuItem menuItem, Menu menu)
        {
            return menu.MenuItems.Contains(menuItem);
        }
    }
}
