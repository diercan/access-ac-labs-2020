using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.GetCartItemOp
{
    [AsChoice]
    public static partial class GetCartItemResult
    {
        public interface IGetCartItemResult { }

        public class CartItemGot : IGetCartItemResult
        {
            public CartItem CartItem { get; }

            public CartItemGot(CartItem item)
            {
                CartItem = item;
            }
        }

        public class NoCartItemGot : IGetCartItemResult
        {
            public String Reason { get; }

            public NoCartItemGot(String error)
            {
                Reason = error;
            }
        }
    }
}