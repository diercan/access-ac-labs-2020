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

        public class EmployeeFound : IGetEmployeeResult 
        { 
            public EmployeeAgg Agg { get; }

            public EmployeeFound(EmployeeAgg agg)
            {
                Agg = agg;
            }
        }

        public class EmployeeNotFound : IGetEmployeeResult
        {
            public string Reason { get; }

            public EmployeeNotFound(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
