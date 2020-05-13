using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;

namespace Domain.Domain.CreateOrderOp
{
    public partial class CreateOrderOp : OpInterpreter<CreateOrderCmd, ICreateOrderResult, Unit>
    {
        public override Task<ICreateOrderResult> Work(CreateOrderCmd Op, Unit state)
        {
            return Task.FromResult<ICreateOrderResult>(new OrderCreated(new OrderAgg(Op.Order))); // Order successfully created
        }
    }
}