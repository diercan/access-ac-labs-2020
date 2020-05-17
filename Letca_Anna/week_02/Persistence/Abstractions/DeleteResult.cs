using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Abstractions
{
    [AsChoice]
    public static partial class DeleteResult
    {
        public interface IDeleteResult { }

        public class Successful : IDeleteResult
        {
            public object Deleted { get; }

            public Successful(object deleted)
            {
                Deleted = deleted;
            }
        }

        public class Failed : IDeleteResult
        {
            public string Reason { get; }

            public Failed(string reason)
            {
                Reason = reason;
            }
        }
    }
}
