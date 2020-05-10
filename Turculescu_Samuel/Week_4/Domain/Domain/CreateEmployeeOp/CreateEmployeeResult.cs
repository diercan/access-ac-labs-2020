using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.CreateEmployeeOp
{
    [AsChoice]
    public static partial class CreateEmployeeResult
    {
        public interface ICreateEmployeeResult { }

        public class EmployeeCreated : ICreateEmployeeResult
        {
            public EmployeeAgg Employee { get; }
            public EmployeeCreated(EmployeeAgg employee)
            {
                Employee = employee;
            }
        }

        public class EmployeeNotCreated : ICreateEmployeeResult
        {
            public string Reason { get; }

            public EmployeeNotCreated(string reason)
            {
                Reason = reason;
            }
        }
    }
}
