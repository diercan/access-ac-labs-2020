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
        public interface ICreateMenuItemResult { }

        public class MenuItemCreated : ICreateMenuItemResult
        {
            public MenuItemAgg MenuItemAgg { get; }

            public MenuItemCreated(MenuItemAgg menuItem)
            {
                MenuItemAgg = menuItem;
            }
        }

        public class MenuItemNotCreated : ICreateMenuItemResult
        {
            public String Reason { get; }

            public MenuItemNotCreated(String reason)
            {
                Reason = reason;
            }
        }
    }
}