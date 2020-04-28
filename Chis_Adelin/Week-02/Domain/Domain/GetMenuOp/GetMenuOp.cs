using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Domain.Domain.GetClientOp;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetMenuOp.GetMenuResult;

namespace Domain.Domain.GetMenuOp
{
    public class GetMenuOp : OpInterpreter<GetMenuCmd, IGetMenuResult, Unit>
    {
        public override Task<IGetMenuResult> Work(GetMenuCmd Op, Unit state)
        {
            for (int i = 0; i< Op.Menus.Length(); i++)
                if(Op.Menus[i].Name == Op.Name)
                    return Task.FromResult<IGetMenuResult>(new MenuFound(Op.Menus[i]));
            return Task.FromResult<IGetMenuResult>(new MenuNotFound("404"));
        }


    }
}