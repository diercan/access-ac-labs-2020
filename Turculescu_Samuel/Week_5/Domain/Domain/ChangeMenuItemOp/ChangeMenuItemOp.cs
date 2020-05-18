using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.ChangeMenuItemOp.ChangeMenuItemResult;

namespace Domain.Domain.ChangeMenuItemOp
{
    public class ChangeMenuItemOp : OpInterpreter<ChangeMenuItemCmd, ChangeMenuItemResult.IChangeMenuItemResult, Unit>
    {
        public override Task<IChangeMenuItemResult> Work(ChangeMenuItemCmd Op, Unit state)
        {
            if(ExistsChanges(Op))
            {
                Op.MenuItem = Op.NewMenuItem;
                return Task.FromResult<IChangeMenuItemResult>(new MenuItemChanged(new MenuItemAgg(Op.MenuItem)));
            }
            else
            {
                return Task.FromResult<IChangeMenuItemResult>(new MenuItemNotChanged("No any changes! The new mwnu item is the same with the current menu item!"));              
            }            
        }

        public bool ExistsChanges(ChangeMenuItemCmd Op)
        {
            if (Op.MenuItem != Op.NewMenuItem)
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
