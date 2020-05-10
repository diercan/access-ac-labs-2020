using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Domain.CreateEntityOp
{
    public class CreateEntityCmd
    {
        public IEntity Entity { get; }

        public CreateEntityCmd(IEntity entity)
        {
            Entity = entity;
        }

        public bool CommandIsValid() => Entity != null;
    }
}