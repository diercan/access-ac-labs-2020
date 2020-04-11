using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;

namespace Domain.Domain.CreateMenuItemOp
{
    class CreateMenuItemOp : OpInterpreter<CreateMenuItemCmd, ICreateMenuItemResult, Unit>
    {
        public override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            return MenuItemExist(Op.ItemName) ?
                Task.FromResult<ICreateMenuItemResult>(new CreateMenuItemResult.MenuItemNotCreated
                ("This menu item already exists")) :
                Task.FromResult<ICreateMenuItemResult>(new CreateMenuItemResult.MenuItemCreated(
                    new Models.MenuItem("Pizza", 14.5m, new List<string> { "Aluat" }, null, null)));
        }

        private bool MenuItemExist(string itemName)
        {
            return true;
        }
    }
}
