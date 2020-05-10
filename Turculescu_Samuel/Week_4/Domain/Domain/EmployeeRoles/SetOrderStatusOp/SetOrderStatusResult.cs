using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using LanguageExt.ClassInstances;

namespace Domain.Domain.EmployeeRoles.SetOrderStatusOp
{
    [AsChoice]
    public static partial class SetOrderStatusResult
    {
        public interface ISetOrderStatusResult { }
        
        public class SetOrderStatusSuccessful : ISetOrderStatusResult
        {
            public Order Order { get; }

            public SetOrderStatusSuccessful(Order order)
            {
                Order = order;
            }
        }
    }
}
