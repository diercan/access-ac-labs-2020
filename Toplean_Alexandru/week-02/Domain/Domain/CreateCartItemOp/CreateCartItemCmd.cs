using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateCartItemOp
{
    public struct CreateCartItemCmd
    {
        public String SessionID { get; }
        public MenuItem MenuItem { get; }
        public uint Quantity { get; }

        public CreateCartItemCmd(String sessionID, MenuItem menuItem, uint Quantity)
        {
            SessionID = sessionID;
            MenuItem = menuItem;
            this.Quantity = Quantity;
        }

        public (bool, String) IsValid()
        {
            return (true, "None");
        }
    }
}