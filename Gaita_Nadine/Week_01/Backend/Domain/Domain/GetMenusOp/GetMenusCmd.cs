using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.GetMenusOp
{
    public class GetMenusCmd
    {
        public Restaurant Restaurant { get; }
        public List<Menu> Menus { get; }
        public GetMenusCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
            Menus = new List<Menu>();
        }
    }

}
