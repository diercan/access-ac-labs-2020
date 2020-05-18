using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Persistence.EfCore;
using System.Linq;

namespace Domain.Domain.GetMenuOp
{
    [AsChoice]
    public static partial class GetMenuResult
    {
        public interface IGetMenuResult { }

        public class MenuFound : IGetMenuResult
        {
            public MenuAgg Agg { get; }

            public MenuFound(MenuAgg agg)
            {
                Agg = agg;
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
