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
        public interface IUpdateEntityResult<IEntity> { }

        public class EntityUpdated<IEntity> : IUpdateEntityResult<IEntity>
        {
            public IEntity Entity { get; }

            public EntityUpdated(IEntity entity)
            {
                Entity = entity;
            }
        }

        public class EntityNotUpdated<IEntity> : IUpdateEntityResult<IEntity>
        {
            public String Reason { get; }

            public EntityNotUpdated(String reason)
            {
                Reason = reason;
            }
        }
    }
}