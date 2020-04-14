
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.AddItemToCartOp.AddItemToCartResult;

namespace Domain.Domain.AddItemToCartOp
{
    public class AddItemToCartOp : OpInterpreter<AddItemToCartCmd, IAddItemToCartResult, Unit>
    {
        public override Task<IAddItemToCartResult> Work(AddItemToCartCmd Op, Unit state)
        {

            var (valid, validationMessage) = Op.Validate();

            if (!valid)
                return Task.FromResult((IAddItemToCartResult)new ItemNotAddedToCart(validationMessage));

            return Task.FromResult((IAddItemToCartResult)new ItemAddedToCart(Op.MenuItem,Op.Client));
        }
    }
}
