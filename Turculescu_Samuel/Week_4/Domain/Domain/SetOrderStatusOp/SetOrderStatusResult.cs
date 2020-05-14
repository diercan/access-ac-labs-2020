using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using LanguageExt.ClassInstances;
using Persistence.EfCore;

namespace Domain.Domain.SetOrderStatusOp
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
