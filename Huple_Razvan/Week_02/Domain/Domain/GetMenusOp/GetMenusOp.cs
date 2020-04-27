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

            foreach(var m in Op.Restaurant.Menus)
                if (m.Name.Equals(Op.Name))
                    return Task.FromResult<IGetMenusResult>((IGetMenusResult)new MenuFound(m));
            return Task.FromResult<IGetMenusResult>((IGetMenusResult)new MenuNotFound("not found"));
        }
    }
}
