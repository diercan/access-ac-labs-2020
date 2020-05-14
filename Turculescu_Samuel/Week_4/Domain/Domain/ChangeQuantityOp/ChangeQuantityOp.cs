using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.ChangeQuantityOp.ChangeQuantityResult;

namespace Domain.Domain.ChangeQuantityOp
{
    public class ChangeQuantityOp : OpInterpreter<ChangeQuantityCmd, ChangeQuantityResult.IChangeQuantityResult, Unit>
    {
        public override Task<IChangeQuantityResult> Work(ChangeQuantityCmd Op, Unit state)
        {
            //Op.CartItem.Quantity = Op.NewQuantity;

            if(Exists(Op.NewQuantity, Op.OrderItem.Quantity))
            {
                return Task.FromResult<IChangeQuantityResult>(new QuantityChanged(new OrderItemAgg(Op.OrderItem)));
            }
            else
            {
                return Task.FromResult<IChangeQuantityResult>(new QuantityNotChanged("Insufficient quantity!"));
            }
        }

        public bool Exists(uint newQuantity, uint existentQuantity)
        {
            if (newQuantity <= existentQuantity)
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
