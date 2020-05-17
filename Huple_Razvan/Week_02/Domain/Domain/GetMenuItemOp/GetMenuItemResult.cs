using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetMenuItemOp
{
    [AsChoice]
    public static partial class GetMenuItemResult
    {
        public interface IGetMenuItemResult { }

        public class MenuItemGot: IGetMenuItemResult
        {
            public MenuItem MenuItem { get; }

            public MenuItemGot(MenuItem menuitem)
            {
                MenuItem = menuitem;
            }
        }

        public class MenuItemNotGot : IGetMenuItemResult
        {
            public string Reason { get; }
            public MenuItemNotGot(string reason)
            {
                Reason = reason;
            }
        }
    }
}
