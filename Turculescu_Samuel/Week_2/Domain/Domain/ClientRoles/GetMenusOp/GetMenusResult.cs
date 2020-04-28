using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.ClientRoles.GetMenusOp
{
    [AsChoice]
    public static partial class GetMenusResult
    {
        public interface IGetMenusResult { }

        public class MenusGotten : IGetMenusResult
        {
            public Menu Menu { get; }

            public MenusGotten(Menu menu)
            {
                Menu = menu;
            }
        }

        public class MenusNotGotten : IGetMenusResult
        {
            public string Reason { get; }

            public MenusNotGotten(string reason)
            {
                Reason = reason;
            }
        }
    }
}
