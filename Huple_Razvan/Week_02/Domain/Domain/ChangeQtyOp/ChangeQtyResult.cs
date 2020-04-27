using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ChangeQtyOp
{
    [AsChoice]
    public static partial class ChangeQtyResult
    {
        public interface IChangeQtyResult { }
        public class ChangeQtySuccessful : IChangeQtyResult
        {
            public Cart Cart { get; }

            public ChangeQtySuccessful(Cart cart)
            {
                Cart = cart;
            }
        }
        public class ChangeQtyNotSuccessful : IChangeQtyResult
        {
            public string Reason { get; }

            public ChangeQtyNotSuccessful(string reason)
            {
                Reason = reason;
            }
        }
    }
}
