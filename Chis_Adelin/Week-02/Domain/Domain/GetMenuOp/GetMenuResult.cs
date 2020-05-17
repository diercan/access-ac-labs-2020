using System;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.GetMenuOp
{
    public static partial class GetMenuResult
    {
        public interface IGetMenuResult{}

        public class MenuFound : IGetMenuResult
        {
            public Menu Menu;

            public MenuFound(Menu menu)
            {
                Menu = menu;
                Console.WriteLine($"Menu {Menu.Name} found ! : ");
            }
        }

        public class MenuNotFound : IGetMenuResult
        {
            public string Reason { get; }

            public MenuNotFound(string reason)
            {
                Reason = reason;
                Console.WriteLine($"Menu not found: {Reason}");
            }
        }
    }
}