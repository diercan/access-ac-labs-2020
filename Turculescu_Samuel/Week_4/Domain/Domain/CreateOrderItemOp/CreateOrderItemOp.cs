using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.CreateOrderItemOp.CreateOrderItemResult;

namespace Domain.Domain.CreateOrderItemOp
{
    public class CreateOrderItemOp : OpInterpreter<CreateOrderItemCmd, CreateOrderItemResult.ICreateOrderItemResult, Unit>
    {
        public override Task<ICreateOrderItemResult> Work(CreateOrderItemCmd Op, Unit state)
        {
            if(Exists(Op.CartItem.Quantity, Op.CartItem.MenuItem.TotalQuantity))
            {
                OrderItemAgg newOrderItemAgg = new OrderItemAgg(new OrderItem { Name = Op.CartItem.Name, MenuItemId = Op.CartItem.MenuItem.Id, OrderId = Op.Order.Id, Quantity = Op.CartItem.Quantity, SpecialRequests = Op.CartItem.SpecialRequests, Price = Op.CartItem.Price});
                return Task.FromResult<ICreateOrderItemResult>(new OrderItemCreated(newOrderItemAgg));
            }
            else
            {
                return Task.FromResult<ICreateOrderItemResult>(new OrderItemNotCreated("Insuficient quantity!"));
            }
        }

        public bool Exists(uint selectedQuantity, uint existentQuantity)
        {
            if (selectedQuantity <= existentQuantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
