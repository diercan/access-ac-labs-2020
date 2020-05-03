using CSharp.Choices.Attributes;
using Persistence.EfCore;
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
            public MenuItems MenuItem;
            public MenuItemCreated(MenuItems menuItem)
            {
                MenuItem = menuItem;
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
