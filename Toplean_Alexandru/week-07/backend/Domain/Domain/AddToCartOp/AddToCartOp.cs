using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Domain.AddToCartOp.AddToCartResult;
using Domain.Models;
using Persistence.EfCore;

namespace Domain.Domain.AddToCartOp
{
    public class AddToCartOp : OpInterpreter<AddToCartCmd, IAddToCartResult, Unit>
    {
        public override Task<IAddToCartResult> Work(AddToCartCmd Op, Unit state)
        {
            if (SessionExists(Op.Client.SessionID))
            {
                if (ClientExists(Op.Client.Client))
                {
                    (bool CommandIsValid, String ErrorReason) = Op.IsValid();
                    if (CommandIsValid)
                    {
                        // Adds the Items to the cart and sets the cart status to CartCreated

                        return Task.FromResult<IAddToCartResult>(new ItemsAddedToCart());
                    }
                    else
                        return Task.FromResult<IAddToCartResult>(new ItemsNotAddedToCart(ErrorReason));
                }
                else
                    return Task.FromResult<IAddToCartResult>(new ItemsNotAddedToCart("The Client does not exist"));
            }
            else
                return Task.FromResult<IAddToCartResult>(new ItemsNotAddedToCart("The session does not exist"));
        }

        public bool SessionExists(String SessionID) => SessionID != null ? true : false;

        public bool ClientExists(Client client) => client != null ? true : false;
    }
}