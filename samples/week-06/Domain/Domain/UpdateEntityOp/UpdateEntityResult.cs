using CSharp.Choices.Attributes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.UpdateEntityOp
{
    [AsChoice]
    public static partial class UpdateEntityResult
    {
        public interface IUpdateEntityResult<T> { }

        public class EntityUpdated<T> : IUpdateEntityResult<T>
        {
            public T Entity { get; }

            public EntityUpdated(T entity)
            {
                Entity = entity;
            }
        }

        public class EntityNotUpdated<T> : IUpdateEntityResult<T>
        {
            public String Reason { get; }

            public EntityNotUpdated(String reason)
            {
                Reason = reason;
            }
        }
    }
}