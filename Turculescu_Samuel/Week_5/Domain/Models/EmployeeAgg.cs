using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class EmployeeAgg
    {        
        public Employee Employee { get; set; }

        public EmployeeAgg(Employee employee)
        {
            Employee = employee;
        }
    }
}
