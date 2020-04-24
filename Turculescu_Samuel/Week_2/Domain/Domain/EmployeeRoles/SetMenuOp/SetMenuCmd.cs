using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.SetMenuOp
{
    public struct SetMenuCmd
    {
        public string MenuName { get; }
        public Employee Employee { get; }

        public SetMenuCmd(Employee employee, string menuName)
        {
            Employee = employee;
            MenuName = menuName;
        }
    }
}
