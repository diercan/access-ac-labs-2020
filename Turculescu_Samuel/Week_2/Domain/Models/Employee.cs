using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }
        public string EmployeeId { get; }

        public Employee(string firstName, string lastName, string email, string phone, string employeeId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            EmployeeId = employeeId;
        }

    }
}
