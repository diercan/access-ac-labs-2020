using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;

namespace Domain.Domain.SelectMenuOp
{
    [AsChoice]
    public static partial class SelectMenuResult
    {
        public interface ISelectMenuResult { }

        public class MenuSelected : ISelectMenuResult
        {
            public Menu Menu { get; }

            public MenuSelected(Menu menu)
            {
                Menu = menu;
            }
        }

        public class MenuNotSelected : ISelectMenuResult
        {
            public String Reason { get; }

            public MenuNotSelected(String Error)
            {
                Reason = Error;
            }
        }
    }
}