using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.GetEmployeeOp
{
    [AsChoice]
    public static partial class GetEmployeeResult
    {
        public interface IGetEmployeeResult { }

        public class GetEmployeeSuccessful : IGetEmployeeResult 
        { 
            public Employee Employee { get; }

            public GetEmployeeSuccessful(Employee employee)
            {
                Employee = employee;
            }
        }

        public class GetEmployeeNotSuccessful : IGetEmployeeResult
        {
            public string Reason { get; }

            public GetEmployeeNotSuccessful(string reason)
            {
                Reason = reason;
            }
        }
    }
}
