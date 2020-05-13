using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.UpdateMenuOp.UpdateMenuResult;

namespace Domain.Domain.UpdateMenuOp
{
    public class UpdateMenuOp : OpInterpreter<UpdateMenuCmd, IUpdateMenuResult, Unit>
    {
        public override Task<IUpdateMenuResult> Work(UpdateMenuCmd Op, Unit state)
        {
            return Task.FromResult<IUpdateMenuResult>(new MenuUpdated(Op.Menu));
        }
    }
}