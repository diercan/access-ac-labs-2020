using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.CreateMenuItemOp
{
    [AsChoice]
    public static partial class CreateMenuItemResult
    {
        public interface ICreateMenuItemResult { }

        public class MenuItemCreated : ICreateMenuItemResult
        {
            public MenuItem MenuItem { get; }

            public MenuItemCreated(MenuItem menuitem)
            {
                MenuItem = menuitem;
            }
        }

        public class MenuItemNotCreated : ICreateMenuItemResult 
        { 
            public string Reason { get; }
            public MenuItemNotCreated(string reason)
            {
                Reason = reason;
            }
        }
    }
}
