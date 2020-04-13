using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuItem
{
    [AsChoice]
    public static partial class CreateMenuItemResult
    {
        public interface ICreateMenuItemResult { }

        public class MenuItemCreated : ICreateMenuItemResult
        {
            public MenuItem MenuItem { get; }

            public MenuItemCreated(MenuItem item)
            {
                MenuItem = item;
            }
        }

        public class MenuItemNotCreated : ICreateMenuItemResult
        {
            public String Reason;

            public MenuItemNotCreated(String error)
            {
                Reason = error;
            }
        }
    }
}