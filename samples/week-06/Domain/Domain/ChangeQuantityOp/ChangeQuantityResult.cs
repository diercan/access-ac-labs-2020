using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.ChangeQuantityOp
{
    [AsChoice]
    public static partial class ChangeQuantityResult
    {
        public interface IChangeQuantityResult { }

        public class QuantityChanged : IChangeQuantityResult
        {
            public QuantityChanged()
            {
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