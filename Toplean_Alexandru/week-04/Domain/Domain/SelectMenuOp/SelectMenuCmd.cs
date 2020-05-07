using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SelectMenuOp
{
    public class SelectMenuCmd
    {
        public Menu Menu;

        public SelectMenuCmd(Menu menu)
        {
            Menu = menu;
        }

        public void CheckIfValid()
        {
            if (Menu == null)
                throw new Exception("The Menu does not exist in the current restaurant");
        }
    }
}