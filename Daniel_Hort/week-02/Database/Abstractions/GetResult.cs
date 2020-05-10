using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Abstractions
{
    [AsChoice]
    public static partial class GetResult
    {
        public interface IGetResult <T> { }

        public class Found <T> : GetResultType<T>
        {
            public List<T> Items { get; }
            public Found(List<T> items)
            {
                Items = items;
            }
        }

        public class NotFound <T> : GetResultType<T>
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

    public abstract class GetResultType<T> : GetResult.IGetResult<T>
    {
    }
}
