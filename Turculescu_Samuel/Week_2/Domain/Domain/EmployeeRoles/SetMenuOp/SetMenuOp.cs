using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred; 
using static Domain.Domain.EmployeeRoles.SetMenuOp.SetMenuResult;

namespace Domain.Domain.EmployeeRoles.SetMenuOp
{
    public class SetMenuOp : OpInterpreter<SetMenuCmd, SetMenuResult.ISetMenuResult, Unit>
    {
        public override Task<ISetMenuResult> Work(SetMenuCmd Op, Unit state)
        {
            Op.Employee.Restaurant.Menu = new Menu(Op.MenuName);

            return Exists(Op.MenuName) ?
                Task.FromResult<ISetMenuResult>(new SetMenuNotSuccessful("This menu already exists!")) :
                Task.FromResult<ISetMenuResult>(new SetMenuSuccessful(Op.Employee.Restaurant.Menu));                
        }

        public bool Exists(string menuName)
        {
            return true;
        }
    }
}
