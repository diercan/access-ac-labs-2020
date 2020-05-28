using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Abstractions
{
    public class AddEntityCmd
    {
        public object Item { get; }

        public AddEntityCmd(object item)
        {
            Item = item;
        }
    }
}