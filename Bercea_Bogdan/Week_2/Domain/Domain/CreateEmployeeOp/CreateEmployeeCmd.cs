using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateEmployeeOp
{
    public struct CreateEmployeeCmd
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public string Address { get; }
        public decimal Salary { get; }
        public Gender Gender { get; }
        public Position Position { get; }

        public Restaurant Restaurant { get; }

        public CreateEmployeeCmd(string firstName, string lastName, int age, string address,
            decimal salary, Gender gender, Position position, Restaurant restaurant)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            Salary = salary;
            Gender = gender;
            Position = position;
            Restaurant = restaurant;
        }
    }
}
