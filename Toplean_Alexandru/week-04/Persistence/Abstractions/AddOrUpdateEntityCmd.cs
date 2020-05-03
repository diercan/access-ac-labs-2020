using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Abstractions
{
    public class AddOrUpdateEntityCmd
    {
        public object Item { get; }

        public AddOrUpdateEntityCmd(object item)
        {
            Item = item;
        }
    }
}