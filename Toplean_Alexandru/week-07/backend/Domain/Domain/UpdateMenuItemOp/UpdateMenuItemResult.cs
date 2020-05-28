using CSharp.Choices.Attributes;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.UpdateMenuItemOp
{
    [AsChoice]
    public static partial class UpdateMenuItemResult
    {
        public interface IUpdateMenuItemResult { }

        public class MenuItemUpdated : IUpdateMenuItemResult
        {
            public MenuItem MenuItem { get; }

            public MenuItemUpdated(MenuItem item)
            {
                MenuItem = item;
            }
        }

        public class MenuItemNotUpdated : IUpdateMenuItemResult
        {
            public String Reason { get; }

            public MenuItemNotUpdated(String reason)
            {
                Reason = reason;
            }
        }
    }
}