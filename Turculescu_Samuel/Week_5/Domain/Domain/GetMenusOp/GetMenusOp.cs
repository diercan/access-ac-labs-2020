using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetMenusOp.GetMenusResult;

namespace Domain.Domain.GetMenusOp
{
    public class GetMenusOp : OpInterpreter<GetMenusCmd, GetMenusResult.IGetMenusResult, Unit>
    {
        public override Task<IGetMenusResult> Work(GetMenusCmd Op, Unit state)
        {
            if(Op.Menus is null)
            {
                return Task.FromResult<IGetMenusResult>(new GetMenusNotSuccessful("Restaurant does not have a menu yet!"));
            }
            else
            {
                return Task.FromResult<IGetMenusResult>(new GetMenusSuccessful(Op.Menus));
            }
            
        }
    }
}
