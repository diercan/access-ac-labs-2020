using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;

namespace Domain.Domain.CreateOrderOp
{
    public class CreateOrderOp : OpInterpreter<CreateOrderCmd, ICreateOrderResult, Unit>
    {
        public override System.Threading.Tasks.Task<ICreateOrderResult> Work(CreateOrderCmd Op, Unit state)
        {
            return Task.FromResult((ICreateOrderResult)new OrderCreated(new Order(Op.Client, Op.Restaurant)));
        }
    }
}
