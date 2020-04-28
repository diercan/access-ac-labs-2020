using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design.Serialization;

namespace Domain.Domain.EmployeeRoles.AddMenuItemOp
{
    public static partial class AddMenuItemResult
    {
        public interface IAddMenuItemResult { }

        public class AddMenuItemSuccessful : IAddMenuItemResult
        {
            public MenuItem MenuItem { get; }
            public AddMenuItemSuccessful(MenuItem menuItem)
            {
                MenuItem = menuItem;    
            }
        }

        public class AddMenuItemNotSuccessful : IAddMenuItemResult
        {
            public string Reason { get; }

            public AddMenuItemNotSuccessful(string reason)
            {
                Reason = reason;
            }
        }
    }
}
