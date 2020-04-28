using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.EmployeeRoles.GetOrderStatusOp.GetOrderStatusResult;

namespace Domain.Domain.EmployeeRoles.GetOrderStatusOp
{
    public class GetOrderStatusOp : OpInterpreter<GetOrderStatusCmd, GetOrderStatusResult.IGetOrderStatusResult, Unit>
    {
        public override Task<IGetOrderStatusResult> Work(GetOrderStatusCmd Op, Unit state)
        {
            return Task.FromResult<IGetOrderStatusResult>(new GetOrderStatus(Op.Order.OrderStatus));
        }
    }
}
