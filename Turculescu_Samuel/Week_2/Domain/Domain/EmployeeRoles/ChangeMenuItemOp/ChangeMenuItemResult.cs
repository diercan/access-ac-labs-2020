using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using System.ComponentModel.Design.Serialization;


namespace Domain.Domain.EmployeeRoles.ChangeMenuItemOp
{
    [AsChoice]
    public static partial class ChangeMenuItemResult
    {
        public interface IChangeMenuItemResult { }

        public class MenuItemChanged : IChangeMenuItemResult
        {
            public MenuItem NewMenuItem { get; }
            public MenuItemChanged(MenuItem newMenuItem)
            {
                NewMenuItem = newMenuItem;
            }
        }

        public class MenuItemNotChanged : IChangeMenuItemResult
        {
            public string Reason { get; }
            public MenuItemNotChanged(string reason)
            {
                Reason = reason;
            }
        }
    }
}
