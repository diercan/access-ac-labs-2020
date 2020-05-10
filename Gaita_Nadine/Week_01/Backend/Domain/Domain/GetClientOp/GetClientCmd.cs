using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetClientOp
{
    public class GetClientCmd
    {
        public string Uid { get; }
        public GetClientCmd(string uid)
        {
            Uid = uid;
        }
    }
}
