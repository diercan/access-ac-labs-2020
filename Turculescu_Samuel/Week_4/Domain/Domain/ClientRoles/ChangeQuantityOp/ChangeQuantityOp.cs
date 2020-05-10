using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.ClientRoles.ChangeQuantityOp.ChangeQuantityResult;

namespace Domain.Domain.ClientRoles.ChangeQuantityOp
{
    public class ChangeQuantityOp : OpInterpreter<ChangeQuantityCmd, ChangeQuantityResult.IChangeQuantityResult, Unit>
    {
        public override Task<IChangeQuantityResult> Work(ChangeQuantityCmd Op, Unit state)
        {
            Op.CartItem.Quantity = Op.NewQuantity;
            
            return !Exists(Op.NewQuantity, Op.CartItem.MenuItem.MenuItem.TotalQuantity) ?
                Task.FromResult<IChangeQuantityResult>(new QuantityNotChanged("Insufficient quantity!")) :
                Task.FromResult<IChangeQuantityResult>(new QuantityChanged(Op.CartItem));
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
