using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetClientOp
{
    public struct GetClientCmd
    {
        public string ClientId { get; }
        public GetClientCmd(string clientId)
        {
            ClientId = clientId;
        }
    }
}
