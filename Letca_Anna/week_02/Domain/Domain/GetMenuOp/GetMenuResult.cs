using System;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using Persistence.EfCore;

namespace Domain.Domain.GetMenuOp
{
    [AsChoice]
    public static partial class GetMenuResult
    {
        public interface IGetMenuResult { }

        public class MenuFound : IGetMenuResult
        {
            public Menus Menu { get; }

            public MenuFound(Menus menu)
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
