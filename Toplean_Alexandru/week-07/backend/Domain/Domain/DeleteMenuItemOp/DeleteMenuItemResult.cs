using CSharp.Choices.Attributes;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.DeleteMenuItemOp
{
    [AsChoice]
    public static partial class DeleteMenuItemResult
    {
        public interface IDeleteMenuItemResult { }

        public class MenuItemDeleted : IDeleteMenuItemResult
        {
            public MenuItem MenuItem { get; }

            public MenuItemDeleted(MenuItem menuItem)
            {
                MenuItem = menuItem;
            }
        }

        public class MenuItemNotDeleted : IDeleteMenuItemResult
        {
            public String Reason { get; }

            public MenuItemNotDeleted(String error)
            {
                Reason = error;
            }
        }
    }
}