using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;

namespace Domain.Domain.GetMenusOp
{
    [AsChoice]
    public static partial class GetMenusResult
    {
        public interface IGetMenusResult { }

        public class MenuFound : IGetMenusResult
        {
            public Menu Menu { get; }

            public MenuFound(Menu menu)
            {
                Menu = menu;
            }
        }

        public class MenuNotFound : IGetMenusResult
        {
            public string Reason { get; }

            public MenuNotFound(string reason)
            {
                Reason = reason;
            }
        }
    }

}
