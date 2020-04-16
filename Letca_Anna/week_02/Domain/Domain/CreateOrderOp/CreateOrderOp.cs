using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;

namespace Domain.Domain.CreateOrderOp
{
    public class CreateOrderOp : OpInterpreter<CreateOrderCmd, ICreateOrderResult, Unit>
    {
        public override Task<ICreateOrderResult> Work(CreateOrderCmd Op, Unit state)
        {
            var (valid, validationMessage) = Op.Validate();

            if (!valid)
                return Task.FromResult((ICreateOrderResult)new OrderNotCreated(validationMessage));

            return Task.FromResult((ICreateOrderResult)new OrderCreated(new Order(Op.Client)));
        }
    }
}

