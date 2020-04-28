using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;

namespace Domain.Domain.GetMenuItemOp
{
    [AsChoice]
    public static partial class GetMenuItemResult
    {
        public interface IGetMenuItemResult { }

        public class MenuItemGot : IGetMenuItemResult
        {
            public MenuItem MenuItem { get; }

            public MenuItemGot(MenuItem menuItem)
            {
                MenuItem = menuItem;
            }
        }

        public class NoMenuItemGot : IGetMenuItemResult
        {
            public String Reason { get; }

            public NoMenuItemGot(String Error)
            {
                Reason = Error;
            }
        }
    }
}