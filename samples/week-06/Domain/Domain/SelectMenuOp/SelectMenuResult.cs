using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.SelectMenuOp
{
    [AsChoice]
    public static partial class SelectMenuResult
    {
        public interface ISelectMenuResult { }

        public class MenuSelected : ISelectMenuResult
        {
            public MenuAgg MenuAgg { get; }

            public MenuSelected(MenuAgg menu)
            {
                MenuAgg = menu;
            }
        }

        public class MenuNotSelected : ISelectMenuResult
        {
            public String Reason { get; }

            public MenuNotSelected(String reason)
            {
                Reason = reason;
            }
        }
    }
}