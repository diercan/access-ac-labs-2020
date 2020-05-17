using System.Collections.Generic;
using Domain.Models;

namespace Domain.Domain.GetMenuOp
{
    public struct GetMenuCmd
    {
        public string Name { get; }
        public List<Menu> Menus { get; }

        public GetMenuCmd(string name,List<Menu> menus)
        {
            Name = name;
            Menus = menus;
        }
    }
}