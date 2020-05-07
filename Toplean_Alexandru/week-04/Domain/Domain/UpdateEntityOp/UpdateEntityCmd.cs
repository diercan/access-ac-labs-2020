using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.UpdateEntityOp
{
    public class UpdateEntityCmd<T>// where T : IEntity
    {
        public T Entity { get; }

        public UpdateEntityCmd(T entity)
        {
            Entity = entity;
        }

        public void CommandIsValid()
        {
            if (Entity == null)
                throw new Exception("Cannot update an inexistent or null entity");
        }
    }
}