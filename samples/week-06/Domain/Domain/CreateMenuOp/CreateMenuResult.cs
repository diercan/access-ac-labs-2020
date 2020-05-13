using CSharp.Choices.Attributes;
using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateMenuOp
{
    [AsChoice]
    public static partial class CreateMenuResult
    {
        public interface ICreateMenuResult { }

        public class MenuCreated : ICreateMenuResult
        {
            public MenuAgg Menu { get; }

            public MenuCreated(MenuAgg menu)
            {
                Menu = menu;
            }
        }

        public class MenuNotCreated : ICreateMenuResult
        {
            public String Reason { get; }

            public MenuNotCreated(String error)
            {
                Reason = error;
            }
        }
    }
}