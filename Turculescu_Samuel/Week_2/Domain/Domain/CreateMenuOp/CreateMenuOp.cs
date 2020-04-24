using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;

namespace Domain.Domain.CreateMenuOp
{
    public class CreateMenuOp : OpInterpreter<CreateMenuCmd, ICreateMenuResult, Unit>
    {
        public override Task<ICreateMenuResult> Work(CreateMenuCmd Op, Unit state)
        {
            Op.Restaurant.Menu = new Menu(Op.MenuName);

            return !Exists(Op.MenuName) ?
                Task.FromResult((ICreateMenuResult)new MenuNotCreated("Menu name already exists!")) :
                Task.FromResult((ICreateMenuResult)new MenuCreated(Op.Restaurant.Menu));
        }

        public bool Exists(string menuName)
        {
            return true;
        }
    }
}
