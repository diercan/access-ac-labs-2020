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
        public override Task<ICreateOrderResult> Work(CreateOrderCmd Op, Unit state)
        {
            if (Op.IsValid().Item1)
            {
                Models.Order order = new Models.Order(Op.OrderID, Op.TableNumber, Op.Items, Op.Waiter, Op.Price);
                Op.Restaurant.Orders.Add(order);
                return Task.FromResult<ICreateOrderResult>(new OrderCreated(order, Op.Restaurant)); // Order successfully created
            }
            else
            {
                return Task.FromResult<ICreateOrderResult>(new OrderNotCreated(Op.IsValid().Item2));  // Order not created and the reason in Op.IsValid().Item2
            }
        }
    }
}