using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateEntityOp
{
    internal class CreateEntityCmd<T>
    {
        public T Entity { get; }

        public CreateEntityCmd(T entity)
        {
            Entity = entity;
        }

        public bool CommandIsValid() => Entity != null;
    }
}