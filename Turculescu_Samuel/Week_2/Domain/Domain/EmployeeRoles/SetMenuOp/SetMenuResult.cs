using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.EmployeeRoles.SetMenuOp
{
    [AsChoice]
    public static partial class SetMenuResult
    {
        public interface ISetMenuResult { }

        public class SetMenuSuccessful : ISetMenuResult
        {
            public Menu Menu { get; }
            
            public SetMenuSuccessful(Menu menu)
            {
                Menu = menu;
            }
        }

        public class SetMenuNotSuccessful : ISetMenuResult
        {
            public string Reason;
           
            public SetMenuNotSuccessful(string reason)
            {
                Reason = reason;
            }
        }
    }
}
