using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetMenusOp.GetMenusResult;

namespace Domain.Domain.GetMenusOp
{
    public class GetMenusOp : OpInterpreter<GetMenusCmd, GetMenusResult.IGetMenusResult, Unit>
    {
        public override Task<IGetMenusResult> Work(GetMenusCmd Op, Unit state)
        {
            //validate
            if (Op.Restaurant.Menus.Contains(Op.Menu))
                return Task.FromResult<IGetMenusResult>((IGetMenusResult)new MenuFound(Op.Menu));
            else
                return Task.FromResult<IGetMenusResult>((IGetMenusResult)new MenuNotFound("not found"));
        }
    }
}
