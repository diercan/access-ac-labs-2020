using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Abstractions
{
    [AsChoice]
    public static partial class UpdateEntityResult
    {
        public interface IUpdateEntityResult { }

        public class Success : IUpdateEntityResult
        {
            public object Item { get; }

            public Success(object item)
            {
                Item = item;
            }
        }

        public class Failed : IUpdateEntityResult
        {
            public String Reason { get; }

            public Failed(String reason)
            {
                Reason = reason;
            }
        }
    }
}