using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.ClientRoles.AddToCartOp
{
    [AsChoice]
    public static partial class AddToCartResult
    {
        public interface IAddToCartResult { }

        public class AddToCartSuccessful : IAddToCartResult
        {
            public CartItem CartItem { get; }

            public AddToCartSuccessful(CartItem cartItem)
            {
                CartItem = cartItem;
            }
        }

        public class AddToCartNotSuccessful : IAddToCartResult
        {
            public string Reason { get; }

            public AddToCartNotSuccessful(string reason)
            {
                Reason = reason;
            }
        }

        public class AddToCartInvalidRequest : IAddToCartResult
        {
            public string Reason { get; }

            public AddToCartInvalidRequest(string reason)
            {
                Reason = reason;
            }
        }
    }
}
