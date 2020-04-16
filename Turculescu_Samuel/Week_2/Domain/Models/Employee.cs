using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Employee
    {
        public string Name { get; }

        public Employee(string name)
        {
            Name = name;
        }

    }
}
