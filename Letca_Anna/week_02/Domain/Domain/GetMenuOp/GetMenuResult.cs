using System;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using Persistence.EfCore;
using System.Collections.Generic;

namespace Domain.Domain.GetMenuOp
{
    [AsChoice]
    public static partial class GetMenuResult
    {
        public interface IGetMenuResult { }

        public class MenuFound : IGetMenuResult
        {
            public List<Menus> Menus { get; }

            public MenuFound(List<Menus> menus)
            {
                Menus = menus;
            }
        }


        public class MenuNotFound : IGetMenuResult
        {
            public string Reason { get; }

            public MenuNotFound(string reason)
            {
                Reason = reason;
            }
        }
    }
}
