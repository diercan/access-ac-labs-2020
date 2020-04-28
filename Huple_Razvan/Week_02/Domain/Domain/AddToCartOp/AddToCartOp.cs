using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.AddToCartOp.AddToCartResult;
namespace Domain.Domain.AddToCartOp
{
    public class AddToCartOp : OpInterpreter<AddToCartCmd, IAddToCartResult, Unit>
    {
        public override Task<IAddToCartResult> Work(AddToCartCmd Op, Unit state)
        {
            //validate
            if (Op.Client == null)
                return Task.FromResult<IAddToCartResult>((IAddToCartResult)new AddToCartInvalidRequest("invalid client"));
            else
                if (Op.Qty == 0)
                return Task.FromResult<IAddToCartResult>((IAddToCartResult)new AddToCartInvalidRequest("qty>0"));
            else
                if (Op.SessionId == null || Op.SessionId.Equals(""))
                return Task.FromResult<IAddToCartResult>((IAddToCartResult)new AddToCartInvalidRequest("invalid sessionId"));
            else
                if (Op.MenuItem == null)
                return Task.FromResult<IAddToCartResult>((IAddToCartResult)new AddToCartInvalidRequest("invalid menu item"));
            else
            {
                Cart c = new Cart(Op.SessionId, Op.Client, Op.Qty, Op.MenuItem);
                return Task.FromResult<IAddToCartResult>((IAddToCartResult)new AddToCartSuccessful(c));
            }

        }
    }
}
