using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Abstractions
{
    public class AddOrUpdateCmd
    {
        public object Item { get; }
        public AddOrUpdateCmd(object item)
        {
            Item = item;
        }
    }
}
