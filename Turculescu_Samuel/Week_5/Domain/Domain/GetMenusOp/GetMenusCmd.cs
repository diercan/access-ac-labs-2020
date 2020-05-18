using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Domain.GetMenusOp
{
    public struct GetMenusCmd
    {
        public List<Menu> Menus { get; }

        public GetMenusCmd(List<Menu> menus)
        {
            Menus = menus;            
        }
    }
}
