using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.CreateMenuOp
{
    [AsChoice]
    public static partial class CreateMenuResult
    {
        public interface ICreateMenuResult { }

        public class MenuCreated : ICreateMenuResult
        {
            public Menu Menu { get; }

            public MenuCreated(Menu menu)
            {
                Menu = menu;
            }
        }

        public class MenuNotCreated : ICreateMenuResult
        {
            public MenuErrorCode Reason { get; }

            public MenuNotCreated(MenuErrorCode error)
            {
                Reason = error;
            }
        }
    }
}