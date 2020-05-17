using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.DeleteEntityOp
{
    internal class DeleteEntityCmd<T>
    {
        public T Entity { get; }

        public DeleteEntityCmd(T entity)
        {
            Entity = entity;
        }

        public bool CommandIsValid() => Entity != null;
    }
}