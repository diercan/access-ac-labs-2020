using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateOrderItemOp.CreateOrderItemResult;

namespace Domain.Domain.CreateOrderItemOp
{
    public class CreateOrderItemOp : OpInterpreter<CreateOrderItemCmd, ICreateOrderItemResult, Unit>
    {
        public override Task<ICreateOrderItemResult> Work(CreateOrderItemCmd Op, Unit state)
        {
            try
            {
                //MenuItem menuItem = new MenuItem(Op.MenuID, Op.Name, Op.Ingredients, Op.Alergens, Op.Price, Op.Image);
                OrderItemAgg orderItemAgg = new OrderItemAgg(Op.OrderItem);
                return Task.FromResult<ICreateOrderItemResult>(new OrderItemCreated(orderItemAgg));  // Restaurant is valid
            }
            catch (Exception exp)
            {
                return Task.FromResult<ICreateOrderItemResult>(new OrderItemNotCreated(exp.Message));  // Restaurant is not valid
            }
        }
    }
}