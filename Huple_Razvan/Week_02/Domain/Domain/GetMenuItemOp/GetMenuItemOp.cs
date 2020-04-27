using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetMenuItemOp.GetMenuItemResult;

namespace Domain.Domain.GetMenuItemOp
{
    public class GetMenuItemOp : OpInterpreter<GetMenuItemCmd, IGetMenuItemResult, Unit>
    {
        public override Task<IGetMenuItemResult> Work(GetMenuItemCmd Op, Unit state)
        {
            foreach(var m in Op.Menu.menuItems)
                if(m.Title.Equals(Op.Title))
                    return Task.FromResult((IGetMenuItemResult)new MenuItemGot(m));
            return Task.FromResult((IGetMenuItemResult)new MenuItemNotGot("does not exists"));
        }
    }
}
