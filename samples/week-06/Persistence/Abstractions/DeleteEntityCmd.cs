using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Abstractions
{
    public class DeleteEntityCmd
    {
        public object Item { get; }

        public DeleteEntityCmd(object item)
        {
            Item = item;
        }
    }
}