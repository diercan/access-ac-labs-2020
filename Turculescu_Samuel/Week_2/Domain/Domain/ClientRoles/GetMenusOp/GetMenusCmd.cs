using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ClientRoles.GetMenusOp
{
    public struct GetMenusCmd
    {
        public Client Client { get; }

        public GetMenusCmd(Client client)
        {
            Client = client;            
        }
    }
}
