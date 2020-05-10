using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.AddToCartOp.AddMenuItemToCartResult;

namespace Domain.Domain.AddToCartOp
{
    public class AddMenuItemToCartOp : OpInterpreter<AddMenuItemToCartCmd, IAddMenuItemToCartResult, Unit>
    {
        public override System.Threading.Tasks.Task<IAddMenuItemToCartResult> Work(AddMenuItemToCartCmd Op, Unit state)
        {
            if(Op.Quantity == 1)
            {
                Op.Client.Cart.MenuItems.Add(Op.MenuItem);
            }
            else if(Op.Quantity > 1)
            {
                while (Op.Quantity<1)
                {
                    Op.Client.Cart.MenuItems.Add(Op.MenuItem);
                }
            }
            return Task.FromResult((IAddMenuItemToCartResult)new MenuItemAddedToCart(Op.MenuItem, Op.Client, Op.Quantity));
        }
    }
}
