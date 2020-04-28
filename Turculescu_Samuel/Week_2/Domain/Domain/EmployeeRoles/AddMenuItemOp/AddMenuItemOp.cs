using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.EmployeeRoles.AddMenuItemOp.AddMenuItemResult;

namespace Domain.Domain.EmployeeRoles.AddMenuItemOp
{
    public class AddMenuItemOp : OpInterpreter<AddMenuItemCmd, AddMenuItemResult.IAddMenuItemResult, Unit>
    {
        public override Task<IAddMenuItemResult> Work(AddMenuItemCmd Op, Unit state)
        {
            return Exists(Op.NewMenuItem.Name) ?
                Task.FromResult<IAddMenuItemResult>(new AddMenuItemNotSuccessful("This menu item already exists!")) :
                Task.FromResult<IAddMenuItemResult>(new AddMenuItemSuccessful(Op.NewMenuItem));
        }

        public bool Exists(string nameMenuItem)
        {
            return true;
        }
    }
}
