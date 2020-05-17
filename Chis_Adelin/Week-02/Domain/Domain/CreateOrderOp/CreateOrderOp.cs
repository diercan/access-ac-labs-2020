using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;

namespace Domain.Domain.CreateOrderOp
{
    class CreateOrderOp : OpInterpreter<CreateOrderCmd, ICreateOrderResult, Unit>
    {
        public override Task<ICreateOrderResult> Work(CreateOrderCmd Op, Unit state)
        {
            if (Op.Price > 100)
                return Task.FromResult<ICreateOrderResult>(new OrderNotCreated("Order Price too high"));
            else
                return Task.FromResult((ICreateOrderResult)new Order(Op.DateTime, Op.Menus, Op.Price));
        }
    }
}
