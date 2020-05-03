using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Abstractions
{
    [AsChoice]
    public static partial class AddOrUpdateEntityResult
    {
        public interface IAddOrUpdateEntityResult { }

        public class Success : IAddOrUpdateEntityResult
        {
            public object Entity { get; }

            public Success(object entity)
            {
                Entity = entity;
            }
        }

        public class Failed : IAddOrUpdateEntityResult
        {
            public String Reason;

            public Failed(String reason)
            {
                Reason = reason;
            }
        }
    }
}