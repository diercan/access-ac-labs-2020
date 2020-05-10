using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.EmployeeRoles.ChangeMenuItemOp.ChangeMenuItemResult;

namespace Domain.Domain.EmployeeRoles.ChangeMenuItemOp
{
    public class ChangeMenuItemOp : OpInterpreter<ChangeMenuItemCmd, ChangeMenuItemResult.IChangeMenuItemResult, Unit>
    {
        public override Task<IChangeMenuItemResult> Work(ChangeMenuItemCmd Op, Unit state)
        {
            if(!ExistsChanges(Op.Menu.MenuItems[Op.MenuItemId], Op.NewMenuItem))
            {
                return Task.FromResult<IChangeMenuItemResult>(new MenuItemNotChanged("No any changes! The new mwnu item is the same with the current menu item!"));
                
            }
            else
            {                
                Op.Menu.MenuItems[Op.MenuItemId] = Op.NewMenuItem;
                return Task.FromResult<IChangeMenuItemResult>(new MenuItemChanged(Op.NewMenuItem));
            }            
        }

        public bool ExistsChanges(MenuItemAgg currentMenuItem, MenuItemAgg newMenuItem)
        {
            if (currentMenuItem != newMenuItem)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
