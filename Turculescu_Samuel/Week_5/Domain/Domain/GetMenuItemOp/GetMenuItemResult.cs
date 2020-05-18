using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Persistence.EfCore;
using System.Linq;

namespace Domain.Domain.GetMenuItemOp
{
    [AsChoice]
    public static partial class GetMenuItemResult
    {
        public interface IGetMenuItemResult { }

        public class MenuItemFound: IGetMenuItemResult
        {
            public MenuItemAgg Agg { get; }

            public MenuItemFound(MenuItemAgg agg)
            {
                Agg = agg;
            }
        }

        public class MenuItemNotFound : IGetMenuItemResult
        {
            public string Reason { get; }

            public MenuItemNotFound(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
