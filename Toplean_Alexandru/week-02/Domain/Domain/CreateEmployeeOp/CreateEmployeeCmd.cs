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

        public (bool, String) IsValid()
        {
            try
            {
                if (EmptyField(Name))
                    return (false, "Name field is empty!");

                if (EmptyField(Salary.ToString()))
                    return (false, "Salary field is empty!");

                if (EmptyField(TelephoneNumber))
                    return (false, "Telephone number field is empty");

                if (EmptyField(IBAN))
                    return (false, "IBAN field is empty");

                if (Restaurant == null)
                    return (false, "No restaurant provided. Restaurant is null");

                if (IncorectInputType(Salary, typeof(float)))
                    return (false, "Salary should be of type float");

                return (true, "None");
            }
            catch (Exception exp)
            {
                return (false, exp.ToString());
            }
        }

        public bool IncorectInputType(dynamic value, Type expectedType) => value.GetType() != expectedType ? true : false;  // Checks if a variable is the correct type

        public bool EmptyField(String name) => name.Length > 0 ? false : true; // Checks if a field is empty
    }
}