using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Employee;

namespace Domain.Domain.CreateEmployeeOp
{
    public struct CreateEmployeeCmd
    {
        public String Name { get; }
        public int Age { get; }
        public String Address { get; }
        public String TelephoneNumber { get; }
        public float Salary { get; }
        public JobRoles JobRole { get; }
        public String IBAN { get; }

        public Restaurant Restaurant { get; }

        public CreateEmployeeCmd(String name, int age, String address, String telephone, float salary, JobRoles role, String iban, Restaurant restaurant)
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

        public (bool, EmployeeErrorCode) IsValid()
        {
            try
            {
                return EmptyField(Name) ? (false, EmployeeErrorCode.EmptyField) : // Empty String - Name
                    EmptyField(Salary.ToString()) ? (false, EmployeeErrorCode.EmptyField) : // Empty String - Salary
                    EmptyField(TelephoneNumber) ? (false, EmployeeErrorCode.EmptyField) : // Empty Strinng - Telephone
                    EmptyField(IBAN) ? (false, EmployeeErrorCode.EmptyField) : // Empty String - IBAN
                    this.Restaurant == null ? (false, EmployeeErrorCode.NullRestaurant) : // Restaurant doesn't exist
                    IncorectInputType(Salary, typeof(float)) ? (false, EmployeeErrorCode.IncorrectInputType) : // Salary value other than float
                    (true, EmployeeErrorCode.None);
            }
            catch
            {
                return (false, EmployeeErrorCode.UnknownError);
            }
        }

        public bool IncorectInputType(dynamic value, Type expectedType) => value.GetType() != expectedType ? true : false;  // Checks if a variable is the correct type

        public bool EmptyField(String name) => name.Length > 0 ? false : true; // Checks if a field is empty
    }
}