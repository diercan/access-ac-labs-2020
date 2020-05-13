using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.DeleteEntityOp
{
    [AsChoice]
    public static partial class DeleteEntityResult
    {
        public interface IDeleteEntityResult<T> { }

        public class EntityDeleted<T> : IDeleteEntityResult<T>
        {
            public T Entity { get; }

            public EntityDeleted(T entity)
            {
                Entity = entity;
            }
        }

        public class EntityNotDeleted<T> : IDeleteEntityResult<T>
        {
            public String Reason { get; }

            public EntityNotDeleted(String reason)
            {
                Reason = reason;
            }
        }
    }
}