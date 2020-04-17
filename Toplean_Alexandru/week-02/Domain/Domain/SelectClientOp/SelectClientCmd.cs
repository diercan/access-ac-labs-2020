using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SelectClientOp
{
    public struct SelectClientCmd
    {
        public String Username { get; }

        public SelectClientCmd(String username)
        {
            Username = username;
        }
    }
}