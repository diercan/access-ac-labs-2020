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
    public class CreateOrderOp : OpInterpreter<CreateOrderCmd, ICreateOrderResult, Unit>
    {
        public override Task<ICreateOrderResult> Work(CreateOrderCmd Op, Unit state)
        {
            (bool CommandIsValid, String ErrorCode) = Op.IsValid();

            if (CommandIsValid)
            {
                Order order = new Order(Op.ClientId, Op.RestaurantId, Op.TableNumber, Op.ItemNames, Op.ItemQuantities, Op.ItemComments, Op.TotalPrice, Op.Status, Op.PaymentStatus);
                //Op.Restaurant.Order.Add(order);
                return Task.FromResult<ICreateOrderResult>(new OrderCreated(new OrderAgg(order))); // Order successfully created
            }
            else
            {
                return Task.FromResult<ICreateOrderResult>(new OrderNotCreated(ErrorCode));  // Order not created and the reason in Op.IsValid().Item2
            }
        }
    }
}