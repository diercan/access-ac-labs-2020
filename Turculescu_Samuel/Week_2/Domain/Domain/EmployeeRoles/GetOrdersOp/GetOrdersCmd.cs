using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.GetOrdersOp
{
    public struct GetOrdersCmd
    {
        public Employee Employee { get; }

        public GetOrdersCmd(Employee employee)
        {
            Employee = employee;
        }
    }
}
