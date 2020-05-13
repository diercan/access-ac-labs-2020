using CSharp.Choices.Attributes;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.UpdateMenuOp
{
    [AsChoice]
    public static partial class UpdateMenuResult
    {
        public interface IUpdateMenuResult { }

        public class MenuUpdated : IUpdateMenuResult
        {
            public Menu Menu { get; }

            public MenuUpdated(Menu menu)
            {
                Menu = menu;
            }
        }

        public class MenuNotUpdated : IUpdateMenuResult
        {
            public String Reason { get; }

            public MenuNotUpdated(String reason)
            {
                Reason = reason;
            }
        }
    }
}