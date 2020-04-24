using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SelectClientOp
{
    public struct SelectClientCmd
    {
        public String SessionID { get; }

        public SelectClientCmd(String sessionID)
        {
            SessionID = sessionID;
        }
    }
}