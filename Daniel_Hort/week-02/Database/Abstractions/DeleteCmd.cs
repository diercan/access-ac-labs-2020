using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Abstractions
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
