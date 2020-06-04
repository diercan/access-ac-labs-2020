using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Persistence.EfCore;
using System.Linq;

namespace Domain.Domain.GetMenuItemsOp
{
    [AsChoice]
    public static partial class GetMenuItemsResult
    {
        public interface IGetMenuItemsResult { }

        public class MenuItemsFound: IGetMenuItemsResult
        {
            public List<MenuItem> MenuItems { get; }

            public MenuItemsFound(List<MenuItem> menuItems)
            {
                MenuItems = menuItems;
            }
        }

        public class MenuItemsNotFound : IGetMenuItemsResult
        {
            public string Reason { get; }

            public MenuItemsNotFound(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
