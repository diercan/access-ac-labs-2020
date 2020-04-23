using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;

namespace Domain.Domain.CreateOrderOp
{
    public class CreateOrderOp : OpInterpreter<CreateOrderCmd, ICreateOrderResult, Unit>
    {
        public override Task<ICreateOrderResult> Work(CreateOrderCmd Op, Unit state)
        {
            Op.Client.Order = new Order(Op.OrderId);
            return Task.FromResult((ICreateOrderResult)new OrderCreated(Op.Client.Order));
        }
    }
}
