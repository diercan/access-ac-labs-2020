using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.GetMenusOp
{
    [AsChoice]
    public static partial class GetMenuResult
    {
        public interface IGetMenusResult { }

        public class MenusFound : IGetMenusResult
        {
            public List<Menu> Menus { get; }
            public MenusFound(List<Menu> menus)
            {
                Menus = menus;
            }
        }

        public class MenusNotFound : IGetMenusResult
        {
            public string Reason { get; }
            public MenusNotFound(string reason)
            {
                Reason = reason;
            }
        }
    }
}
