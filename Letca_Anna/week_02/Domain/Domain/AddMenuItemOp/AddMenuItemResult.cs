using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.AddMenuItemOp

{
    [AsChoice]
    public static partial class AddMenuItemResult
    {
        public interface IAddMenuItemResult { };

        public class MenuItemAdded : IAddMenuItemResult
        {
            public MenuItem MenuItem;
            public Menu Menu;
            public MenuItemAdded(MenuItem menuItem, Menu menu)
            {
                Menu = menu;
                MenuItem = menuItem;
                Menu.AddMenuItem(MenuItem);
            }
        }

        public class MenuItemNotAdded : IAddMenuItemResult
        {
            public string Reason { get; }

            public MenuItemNotAdded(string reason)
            {
                Reason = reason;
                Console.WriteLine(reason);
            }
        }
    }
}
