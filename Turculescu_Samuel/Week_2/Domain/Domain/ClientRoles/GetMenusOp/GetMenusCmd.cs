using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ClientRoles.GetMenusOp
{
    public struct GetMenusCmd
    {
        public Client Client { get; }
        public Menu Menu { get; }

        public GetMenusCmd(Client client, Menu menu)
        {
            Client = client;
            Menu = menu;
        }
    }
}
