using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.ChangeQtyOp.ChangeQtyResult;

namespace Domain.Domain.ChangeQtyOp
{
    public class ChangeQtyOp : OpInterpreter<ChangeQtyCmd, IChangeQtyResult, Unit>
    {
        public override Task<IChangeQtyResult> Work(ChangeQtyCmd Op, Unit state)
        {
            //validate
            if (Op.NewQty == 0)
                return Task.FromResult<IChangeQtyResult>((IChangeQtyResult)new ChangeQtyNotSuccessful("qty>0"));
            Cart c = new Cart(Op.SessionId, Op.Client, Op.NewQty, Op.MenuItem);
            return Task.FromResult<IChangeQtyResult>((IChangeQtyResult)new ChangeQtySuccessful(c));
        }
    }
}
