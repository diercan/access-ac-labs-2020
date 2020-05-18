using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetMenusOp.GetMenuResult;

namespace Domain.Domain.GetMenusOp
{
    public class GetMenusOp : OpInterpreter<GetMenusCmd, IGetMenusResult, Unit>
    {
        public override Task<IGetMenusResult> Work(GetMenusCmd Op, Unit state)
        {
            return Task.FromResult<IGetMenusResult>(new MenusFound(Op.Menus));
        }
    }
}
