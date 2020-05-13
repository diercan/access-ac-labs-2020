using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SelectMenuItemOp
{
    public class SelectMenuItemCmd
    {
        public MenuItem MenuItem { get; }

        public SelectMenuItemCmd(MenuItem menuItem)
        {
            MenuItem = menuItem;
        }

        public void CheckIfValid()
        {
            if (MenuItem == null)
                throw new Exception("There is no menu item that matches the criteria");
        }
    }
}