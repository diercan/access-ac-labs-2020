using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class EmployeeAgg
    {
        public enum JobRoles
        {
            Waiter,
            Cook,
            Cashier,
            Maid,
            Provisioner
        };

        public Employee Employee { get; }

        public String Name { get; }

        public int Age { get; }

        public String Address { get; }

        public String TelephoneNumber { get; }

        public float Salary { get; }

        public JobRoles JobRole { get; }

        public String IBAN { get; }

        public EmployeeAgg(Employee employee)
        {
            Employee = employee;
        }
    }
}