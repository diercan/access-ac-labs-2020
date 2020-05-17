using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.SelectMenuItemOp.SelectMenuItemResult;
using static Domain.Domain.SelectMenuOp.SelectMenuResult;

namespace Domain.Domain.SelectMenuItemOp
{
    internal class SelectMenuItemOp : OpInterpreter<SelectMenuItemCmd, ISelectMenuItemResult, Unit>
    {
        public override Task<ISelectMenuItemResult> Work(SelectMenuItemCmd Op, Unit state)
        {
            try
            {
                Op.CheckIfValid();
                return Task.FromResult<ISelectMenuItemResult>(new MenuItemSelected(new MenuItemAgg(Op.MenuItem)));
            }
            catch (Exception exp)
            {
                return Task.FromResult<ISelectMenuItemResult>(new MenuItemNotSelected(exp.Message));
            }
        }
    }
}