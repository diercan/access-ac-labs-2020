using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Employee
    {
        public enum EmployeeErrorCode
        {
            EmptyField,
            IncorrectInputType,
            NameExists,
            None,
            UnknownError,
            NullRestaurant
        }

        public enum JobRoles
        {
            Waiter,
            Cook,
            Cashier,
            Maid,
            Provisioner
        };

        public String Name { get; }
        public int Age { get; }
        public String Address { get; }
        public String TelephoneNumber { get; }
        public float Salary { get; }
        public JobRoles JobRole { get; }
        public String IBAN { get; }

        public Restaurant Restaurant { get; }

        public Employee(String name, int age, String address, String telephone, float salary, JobRoles role, String iban, Restaurant restaurant)
        {
            this.Name = name;
            this.Age = age;
            this.Address = address;
            this.TelephoneNumber = telephone;
            this.Salary = salary;
            this.JobRole = role;
            this.IBAN = iban;
            this.Restaurant = restaurant;
        }
    }
}