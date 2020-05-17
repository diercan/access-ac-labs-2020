using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetMenuItemOp
{
    public struct GetMenuItemCmd
    {   
        public Menu Menu { get; }

        public string Title { get; }


        public GetMenuItemCmd(Menu menu, string title)
        {
            Menu = menu;
            Title = title;
        }
    }
}
