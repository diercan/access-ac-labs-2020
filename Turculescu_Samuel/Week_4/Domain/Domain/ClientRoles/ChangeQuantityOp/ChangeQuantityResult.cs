using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.ClientRoles.ChangeQuantityOp
{
    [AsChoice]
    public static partial class ChangeQuantityResult
    {
        public interface IChangeQuantityResult { }

        public class QuantityChanged : IChangeQuantityResult
        {
            public CartItem NewCartItem { get; }
            public QuantityChanged(CartItem cartItem)
            {
                NewCartItem = cartItem;
            }
        }

        public class QuantityNotChanged : IChangeQuantityResult
        {
            public string Reason { get; }
            
            public QuantityNotChanged(string reason)
            {
                Reason = reason;
            }
        }
    }
}
