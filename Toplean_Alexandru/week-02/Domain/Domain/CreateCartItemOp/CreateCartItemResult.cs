using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateCartItemOp
{
    [AsChoice]
    public static partial class CreateCartItemResult
    {
        public interface ICreateCartItemResult { }

        public class CartItemCreated : ICreateCartItemResult
        {
            public CartItem CartItem { get; }

            public CartItemCreated(CartItem item)
            {
                CartItem = item;
            }
        }

        public class CartItemNotCreated : ICreateCartItemResult
        {
            public String Reason { get; }

            public CartItemNotCreated(String Error)
            {
                Reason = Error;
            }
        }
    }
}