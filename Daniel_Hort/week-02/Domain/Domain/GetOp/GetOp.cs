using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetOp.GetResult;

namespace Domain.Domain.GetOp
{
    class GetOp<T> : OpInterpreter<GetCmd<T>, GetResult.IGetResult<T>, Unit>
    {
        public override Task<GetResult.IGetResult<T>> Work(GetCmd<T> Op, Unit state)
        {
            if (Op.Items.Count == 0)
                return Task.FromResult((IGetResult<T>)new NotFound<T>(NotFoundReason.EmptyList));

            var result = Op.Items.FindAll(Op.Expression);

            if(result.Count == 0)
                return Task.FromResult((IGetResult<T>)new NotFound<T>(NotFoundReason.ExpressionNotMatched));

            return Task.FromResult((IGetResult<T>)new Found<T>(result));
        }
    }
}
