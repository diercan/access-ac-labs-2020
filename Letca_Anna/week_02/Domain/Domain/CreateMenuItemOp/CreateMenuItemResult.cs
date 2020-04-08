using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateMenuItemOp
{
    [AsChoice]
    public static partial class CreateMenuItemResult
    {
        public interface ICreateMenuItemResult { };

        public class MenuItemCreated : ICreateMenuItemResult
        {
            public MenuItem MenuItem;
            public Menu Menu;
            public MenuItemCreated(MenuItem menuItem, Menu menu)
            {
                MenuItem = menuItem;
                Menu = menu;
            }
        }

        public class MenuItemNotCreated : ICreateMenuItemResult
        {
            public string Reason { get; }

            public MenuItemNotCreated(string reason)
            {
                Reason = reason;
                Console.WriteLine(reason);
            }
        }
    }
}
