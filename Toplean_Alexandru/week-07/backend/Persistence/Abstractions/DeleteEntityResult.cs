using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Abstractions
{
    [AsChoice]
    public static partial class DeleteEntityResult
    {
        public interface IDeteleEntityResult { }

        public class Success : IDeteleEntityResult
        {
        }

        public class Failed : IDeteleEntityResult
        {
            public String Reason { get; }

            public Failed(String reason)
            {
                Reason = reason;
            }
        }
    }
}