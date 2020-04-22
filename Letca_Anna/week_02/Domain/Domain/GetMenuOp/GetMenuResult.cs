using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.GetMenuOp
{
    [AsChoice]
    public static partial class GetMenuResult
    {
        public interface IGetMenuResult { }

        public class MenuFound : IGetMenuResult
        {
            public Menu Menu { get; }

            public MenuFound(Menu menu)
            {
                Menu = menu;
            }
        }


        public class MenuNotFound : IGetMenuResult
        {
            public string Reason { get; }

            public MenuNotFound(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
