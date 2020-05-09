using System;
using System.Text;
using Persistence.EfCore;

namespace Domain.Domain.GetEmployeeOp
{
    public struct GetEmployeeCmd
    {
        public Employee Employee { get; }

        public GetEmployeeCmd(Employee employee)
        {
            Employee = employee;
        }
    }
}
