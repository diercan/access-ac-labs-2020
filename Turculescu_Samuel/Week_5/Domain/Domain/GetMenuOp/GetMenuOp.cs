using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetMenuOp.GetMenuResult;

namespace Domain.Domain.GetMenuOp
{
    class GetMenuOp : OpInterpreter<GetMenuCmd, GetMenuResult.IGetMenuResult, Unit>
    {
        public override Task<IGetMenuResult> Work(GetMenuCmd Op, Unit state)
        {
            return (Op.Menu is null) ?
                Task.FromResult<IGetMenuResult>(new MenuNotFound("Menu not found!")) :
                Task.FromResult<IGetMenuResult>(new MenuFound(new MenuAgg(Op.Menu)));
        }
    }
}

