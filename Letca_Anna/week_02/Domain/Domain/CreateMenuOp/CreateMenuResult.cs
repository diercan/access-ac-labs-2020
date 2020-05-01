using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using System.Threading.Tasks;
using Persistence.EfCore;

namespace Domain.Domain.CreateMenuOp
{
    [AsChoice]
    public static partial class CreateMenuResult
    {
        public interface ICreateMenuResult { }

        public class MenuCreated : ICreateMenuResult
        {
            public Menus Menu { get; }

            public MenuCreated(Menus menu)
            {
                Menu = menu;
            }
        }

        public class MenuNotCreated : ICreateMenuResult
        {
            public string Reason { get; }
            public MenuNotCreated(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
