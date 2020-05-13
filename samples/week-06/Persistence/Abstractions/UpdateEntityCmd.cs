using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Abstractions
{
    public class UpdateEntityCmd
    {
        public object Item { get; }

        public UpdateEntityCmd(object item)
        {
            Item = item;
        }
    }
}