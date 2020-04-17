using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.AddToCartOp
{
    [AsChoice]
    public static partial class AddToCartResult
    {
        public interface IAddToCartResult { }

        public class ItemsAddedToCart : IAddToCartResult
        {
        }

        public class ItemsNotAddedToCart : IAddToCartResult
        {
            public String Reason { get; }

            public ItemsNotAddedToCart(String reason)
            {
                Reason = reason;
            }
        }
    }
}