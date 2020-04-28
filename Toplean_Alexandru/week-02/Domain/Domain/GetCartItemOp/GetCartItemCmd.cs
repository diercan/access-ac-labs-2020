using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetCartItemOp
{
    public struct GetCartItemCmd
    {
        public String SessionID { get; }
        public MenuItem MenuItem { get; }

        public GetCartItemCmd(String sessionID, MenuItem menuItem)
        {
            SessionID = sessionID;
            MenuItem = menuItem;
        }

        public (bool, String) IsValid()
        {
            return (true, "None");
        }
    }
}