using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateEntityOp
{
    [AsChoice]
    public static partial class CreateEntityResult
    {
        public interface ICreateEntityResult<T> { }

        public class EntityCreated<T> : ICreateEntityResult<T>
        {
            public T Entity { get; }

            public EntityCreated(T entity)
            {
                Entity = entity;
            }
        }

        public class EntityNotCreated<T> : ICreateEntityResult<T>
        {
            public String Reason { get; }

            public EntityNotCreated(String reason)
            {
                Reason = reason;
            }
        }
    }
}