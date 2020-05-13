using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SelectMenuItemOp
{
    [AsChoice]
    public static partial class SelectMenuItemResult
    {
        public interface ISelectMenuItemResult { }

        public class MenuItemSelected : ISelectMenuItemResult
        {
            public MenuItemAgg MenuItemAgg { get; }

            public MenuItemSelected(MenuItemAgg menuItemAgg)
            {
                MenuItemAgg = menuItemAgg;
            }
        }

        public class MenuItemNotSelected : ISelectMenuItemResult
        {
            public String Reason { get; }

            public MenuItemNotSelected(String reason)
            {
                Reason = reason;
            }
        }
    }
}