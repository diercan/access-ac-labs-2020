using System;
using System.Text;
using Persistence.EfCore;

namespace Domain.Domain.GetClientOp
{
    public struct GetClientCmd
    {
        public Client Client { get; }
        public GetClientCmd(Client client)
        {
            Client = client;
        }
    }
}
