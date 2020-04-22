using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Domain.CreateCartItemOp.CreateCartItemResult;
using Domain.Models;

namespace Domain.Domain.CreateCartItemOp
{
    public class CreateCartItemOp : OpInterpreter<CreateCartItemCmd, ICreateCartItemResult, Unit>
    {
        public override Task<ICreateCartItemResult> Work(CreateCartItemCmd Op, Unit state)
        {
            if (SessionExists(Op.SessionID))
            {
                if (CartExists(Op.SessionID))
                {
                    (bool CommandIsValid, String Error) = Op.IsValid();
                    if (CommandIsValid)
                    {
                        // Creates the cart item and adds it to the list
                        CartItem Item = new CartItem(Op.MenuItem, Op.Quantity);
                        AllHardcodedValues.HarcodedVals.Carts[Op.SessionID].CartItems.Add(Item);

                        // Returns a CartItemCreated with the new Cart Item;
                        return Task.FromResult<ICreateCartItemResult>(new CartItemCreated(Item));
                    }
                    else
                        return Task.FromResult<ICreateCartItemResult>(new CartItemNotCreated(Error)); // IsValid function returned false
                }
                else return Task.FromResult<ICreateCartItemResult>(new CartItemNotCreated("The cart no longer exists")); // Inexistent cart
            }
            else
                return Task.FromResult<ICreateCartItemResult>(new CartItemNotCreated("The session no longer exists")); // Session does not exist
        }

        public bool SessionExists(String SessionID) => AllHardcodedValues.HarcodedVals.Carts.ContainsKey(SessionID);

        public bool CartExists(String SessionID) => AllHardcodedValues.HarcodedVals.Carts[SessionID] != null;
    }
}