using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.GetOp
{
    [AsChoice]
    public static partial class GetResult
    {
        public interface IGetResult <T> { }

        public class Found <T> : IGetResult<T>
        {
            public List<T> Items { get; }
            public Found(List<T> items)
            {
                Items = items;
            }
        }

        public class NotFound <T> : IGetResult<T>
        {
            public NotFoundReason Reason { get; }
            public NotFound(NotFoundReason reason) 
            {
                Reason = reason;
            }
        }

        [Flags]
        public enum NotFoundReason
        {
            EmptyList,
            ExpressionNotMatched
        }
    }
}
