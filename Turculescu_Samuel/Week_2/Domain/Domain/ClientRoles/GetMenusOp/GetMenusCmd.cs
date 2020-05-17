using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ClientRoles.GetMenusOp
{
    public struct GetMenusCmd
    {
        public Restaurant Restaurant { get; }

        public GetMenusCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;            
        }
    }
}
