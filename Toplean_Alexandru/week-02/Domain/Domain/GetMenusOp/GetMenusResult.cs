using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetMenusOp
{
    [AsChoice]
    public static partial class GetMenusResult
    {
        public interface IGetMenusResult { }

        public class MenusGot : IGetMenusResult
        {
            public List<Menu> Menus { get; }

            public MenusGot(List<Menu> menus)
            {
                Menus = menus;
            }
        }

        public class NoMenusGot : IGetMenusResult
        {
            public String Reason { get; }

            public NoMenusGot(String reason)
            {
                Reason = reason;
            }
        }
    }
}