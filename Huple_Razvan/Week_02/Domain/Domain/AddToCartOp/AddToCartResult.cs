using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.AddToCartOp
{
    [AsChoice]
    public static partial class AddToCartResult
    {
        public interface IAddToCartResult { }
        public class AddToCartSuccessful : IAddToCartResult
        {
            public Cart Cart { get; }

            public AddToCartSuccessful(Cart cart)
            {
                Cart = cart;
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
