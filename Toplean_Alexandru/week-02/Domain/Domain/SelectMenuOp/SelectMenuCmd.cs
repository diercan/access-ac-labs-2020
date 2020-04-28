using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SelectMenuOp
{
    public struct SelectMenuCmd
    {
        public Restaurant Restaurant { get; }
        public String MenuName { get; }

        public SelectMenuCmd(Restaurant restaurant, String menuName)
        {
            Restaurant = restaurant;
            MenuName = menuName;
        }

        public (bool, String) IsValid()
        {
            return (true, "None");
        }
    }
}