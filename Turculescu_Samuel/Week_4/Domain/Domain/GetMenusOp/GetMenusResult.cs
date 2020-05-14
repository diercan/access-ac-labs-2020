using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Persistence.EfCore;

namespace Domain.Domain.GetMenusOp
{
    [AsChoice]
    public static partial class GetMenusResult
    {
        public interface IGetMenusResult { }

        public class GetMenusSuccessful : IGetMenusResult
        {            
            public ICollection<Menu> Menus { get; }

            public GetMenusSuccessful(ICollection<Menu> menus)
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
