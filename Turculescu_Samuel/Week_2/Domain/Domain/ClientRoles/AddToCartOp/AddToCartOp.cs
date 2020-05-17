using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.ClientRoles.AddToCartOp.AddToCartResult;

namespace Domain.Domain.ClientRoles.AddToCartOp
{
    public class AddToCartOp : OpInterpreter<AddToCartCmd, AddToCartResult.IAddToCartResult, Unit>
    {
        public override Task<IAddToCartResult> Work(AddToCartCmd Op, Unit state)
        {
            CartItem newCartItem = new CartItem(Op.MenuItem, Op.MenuItem.Name, Op.SpecialRequests, Op.Quantity, Op.MenuItem.Price);
            
            // Validate
            if(Verify(Op.SessionId))
            {
                return !Exists(Op.Quantity, Op.MenuItem.Quantity) ?
                    Task.FromResult<IAddToCartResult>(new AddToCartNotSuccessful("Insuficient quantity!")) :
                    Task.FromResult<IAddToCartResult>(new AddToCartSuccessful(newCartItem)); 
            }
            else
            {
                return Task.FromResult<IAddToCartResult>(new AddToCartInvalidRequest("You should be logged in!"));
            }
        }

        public bool Verify(string ssessionId)
        {
            return true;
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
