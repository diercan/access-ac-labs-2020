using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Name field is mandatory")]
        public String Name { get; }

        [Required(ErrorMessage = "Age field is mandatory")]
        [Range(16, 100, ErrorMessage = "The age must be between 16 and 100")]
        public int Age { get; }

        [Required(ErrorMessage = "Address field is mandatory")]
        public String Address { get; }

        [Required(ErrorMessage = "Telephone field is mandatory")]
        [Phone]
        public String TelephoneNumber { get; }

        [Required(ErrorMessage = "Salary field is mandatory")]
        public float Salary { get; }

        public JobRoles JobRole { get; }

        [Required(ErrorMessage = "IBAN field is mandatory")]
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