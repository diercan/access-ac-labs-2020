using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.ClientRoles.GetMenusOp.GetMenusResult;

namespace Domain.Domain.ClientRoles.GetMenusOp
{
    public class GetMenusOp : OpInterpreter<GetMenusCmd, GetMenusResult.IGetMenusResult, Unit>
    {

        public override Task<IGetMenusResult> Work(GetMenusCmd Op, Unit state)
        {
            return Task.FromResult<IGetMenusResult>(new MenusGotten(Op.Client.GoToRestaurant.Menu));
        }
    }
}
