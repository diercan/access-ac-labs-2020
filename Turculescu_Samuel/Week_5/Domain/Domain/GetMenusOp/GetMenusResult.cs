using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Persistence.EfCore;
using System.Linq;

namespace Domain.Domain.GetMenusOp
{
    [AsChoice]
    public static partial class GetMenusResult
    {
        public interface IGetMenusResult { }

        public class GetMenusSuccessful : IGetMenusResult
        {            
            public List<Menu> Menus; 

            public GetMenusSuccessful(List<Menu> menus)
            {
                Menus = menus;

            }
        }

        public class GetMenusNotSuccessful : IGetMenusResult
        {
            public string Reason { get; }

            public GetMenusNotSuccessful(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
