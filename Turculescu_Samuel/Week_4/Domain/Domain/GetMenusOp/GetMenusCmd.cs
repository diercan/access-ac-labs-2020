using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetMenusOp
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
