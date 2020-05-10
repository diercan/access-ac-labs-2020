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

        public class GetMenusSuccessful : IGetMenusResult
        {
            public List<MenuAgg> Menus { get; }

            public GetMenusSuccessful(List<MenuAgg> menus)
            {
                Menus = menus;
            }
        }

        public class GetMenusNotSuccessful : IGetMenusResult
        {
            public string Reason { get; }

            public GetMenusNotSuccessful(string reason)
            {
                Reason = reason;
            }
        }
    }
}
