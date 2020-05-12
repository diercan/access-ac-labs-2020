using CSharp.Choices.Attributes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateEntityOp
{
    [AsChoice]
    public static partial class CreateEntityResult
    {
        public interface ICreateEntityResult { }

        public class EntityCreated : ICreateEntityResult
        {
            public IEntity Entity { get; }

            public EntityCreated(IEntity entity)
            {
                Entity = entity;
            }
        }

        public class EntityNotCreated : ICreateEntityResult
        {
            public String Reason { get; }

            public EntityNotCreated(String reason)
            {
                Reason = reason;
            }
        }
    }
}