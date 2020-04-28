using Domain.Domain.GetMenuItemOp;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetMenuItemOp.GetMenuItemResult;
using static Domain.Domain.GetCartItemOp.GetCartItemResult;

namespace Domain.Domain.GetCartItemOp
{
    public class GetCartItemOp : OpInterpreter<GetCartItemCmd, IGetCartItemResult, Unit>
    {
        public override Task<IGetCartItemResult> Work(GetCartItemCmd Op, Unit state)
        {
            if (SessionExists(Op.SessionID))
            {
                if (CartExists(Op.SessionID))
                {
                    if (MenuItemExists(Op.SessionID, Op.MenuItem))
                    {
                        (bool CommandIsValid, String Error) = Op.IsValid();

                        var cartItem = AllHardcodedValues.HarcodedVals.Carts[Op.SessionID].CartItems.FirstOrDefault(c => c.MenuItem == Op.MenuItem);

                        return CommandIsValid ?
                            Task.FromResult<IGetCartItemResult>(new CartItemGot(cartItem)) :
                            Task.FromResult<IGetCartItemResult>(new NoCartItemGot(Error));
                    }
                    else
                        return Task.FromResult<IGetCartItemResult>(new NoCartItemGot("There menu item does not exist in the cart"));
                }
                else
                    return Task.FromResult<IGetCartItemResult>(new NoCartItemGot("The cart does not exist"));
            }
            else
                return Task.FromResult<IGetCartItemResult>(new NoCartItemGot("The session does not exist"));
        }

        public bool SessionExists(String SessionID) => AllHardcodedValues.HarcodedVals.Carts.ContainsKey(SessionID);

        public bool MenuItemExists(String sessionID, MenuItem menuItem) => AllHardcodedValues.HarcodedVals.Carts[sessionID].CartItems.Any(c => c.MenuItem == menuItem);

        public bool CartExists(String SessionID) => AllHardcodedValues.HarcodedVals.Carts[SessionID] != null;
    }
}