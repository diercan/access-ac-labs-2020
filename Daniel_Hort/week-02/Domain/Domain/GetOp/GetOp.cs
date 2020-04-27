using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetOp.GetResult;

namespace Domain.Domain.GetOp
{
    public class GetOp<T, C, R> : OpInterpreter<C, R, Unit>
        where C : GetCmd<T>
        where R : GetResultType<T>
    {
        public override Task<R> Work(C Op, Unit state)
        {
            if (Op.Items.Count == 0)
                return Task.FromResult(new NotFound<T>(NotFoundReason.EmptyList) as R);

            var result = Op.Items.FindAll(Op.Expression);

            if(result.Count == 0)
                return Task.FromResult(new NotFound<T>(NotFoundReason.ExpressionNotMatched) as R);

            return Task.FromResult(new Found<T>(result) as R);
        }
    }

    class GetRestaurantOp : GetOp<Restaurant, GetCmd<Restaurant>, GetResultType<Restaurant>> { }
    class GetMenuOp : GetOp<Menu, GetCmd<Menu>, GetResultType<Menu>> { }
    class GetClientOp : GetOp<Client, GetCmd<Client>, GetResultType<Client>> { }
}
