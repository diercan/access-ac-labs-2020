using System;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.GetMenuItemResult
{
    [AsChoice]
    public static partial class MenuItemResult
    {
        public interface IGetMenuItemResult { }

        public class MenuItemFound : IGetMenuItemResult
        {
            public MenuItem MenuItem { get; }

            public MenuItemFound(MenuItem menuItem)
            {
                MenuItem = menuItem;
            }
        }


        public class MenuItemNotFound : IGetMenuItemResult
        {
            public string Reason { get; }

            public MenuItemNotFound(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}