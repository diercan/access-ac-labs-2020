using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.CreateEmployeeOp;

namespace Domain.Domain.CreateEmployeeOp
{
    [AsChoice]
    public static partial class CreateEmployeeResult
    {
        public interface ICreateEmployeeResult { }

        public class EmployeeCreated : ICreateEmployeeResult
        {
            public Employee Employee { get; }

            public EmployeeCreated(Employee employee)
            {
                Employee = employee;
            }
        }

        public class EmployeeNotCreated : ICreateEmployeeResult
        {
            public string ErrorMessage { get; }

            public EmployeeNotCreated(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
    }
}
