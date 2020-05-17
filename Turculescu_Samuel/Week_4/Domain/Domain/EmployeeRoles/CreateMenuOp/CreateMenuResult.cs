using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.EmployeeRoles.CreateMenuOp
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
            public string Reason { get; }
            public MenuNotCreated(string reason)
            {
                Reason = reason;
            }
        }
    }
}
