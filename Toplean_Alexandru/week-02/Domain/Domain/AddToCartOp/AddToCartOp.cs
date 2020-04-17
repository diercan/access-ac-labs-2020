using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.AddToCartOp.AddToCartResult;

namespace Domain.Domain.AddToCartOp
{
    public class AddToCartOp : OpInterpreter<AddToCartCmd, IAddToCartResult, Unit>
    {
        public override Task<IAddToCartResult> Work(AddToCartCmd Op, Unit state)
        {
            (bool CommandIsValid, String ErrorReason) = Op.IsValid();
            if (CommandIsValid)
            {
                // Adds the Items to the cart and sets the cart status to CartCreated
                AllHardcodedValues.HarcodedVals.Carts[Op.SessionID].CartItems = Op.CartItems;
                AllHardcodedValues.HarcodedVals.Carts[Op.SessionID].Status = Models.Cart.CartStatus.CartCreated;
                return Task.FromResult<IAddToCartResult>(new ItemsAddedToCart());
            }
            else
                return Task.FromResult<IAddToCartResult>(new ItemsNotAddedToCart(ErrorReason));
        }
    }
}