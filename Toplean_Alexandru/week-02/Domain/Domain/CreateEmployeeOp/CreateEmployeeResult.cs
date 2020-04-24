using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using static Domain.Models.Employee;

namespace Domain.Domain.CreateEmployeeOp
{
    [AsChoice]
    public static partial class CreateEmployeeResult
    {
        public class EmployeeCreated : ICreateEmployeeResult // Employee successfully created
        {
            public Employee Employee { get; }

            public EmployeeCreated(Employee emp)
            {
                Employee = emp;
            }
        }

        public class EmployeeNotCreated : ICreateEmployeeResult // Employee not created
        {
            public String Reason { get; }

            public EmployeeNotCreated(String code)
            {
                Reason = code;
            }
        }

        public interface ICreateEmployeeResult
        {
        }
    }
}