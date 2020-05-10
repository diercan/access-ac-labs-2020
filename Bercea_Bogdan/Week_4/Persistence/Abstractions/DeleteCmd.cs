using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Abstractions
{
    public class DeleteCmd
    {
        public object Item { get; }

        public DeleteCmd(object item)
        {
            Item = item;
        }
    }
}
