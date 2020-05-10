using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using System.Threading.Tasks;

namespace Database.Abstractions
{
    [AsChoice]
    public static partial class AddOrUpdateResult
    {
        public interface IAddOrUpdateResult { }

        public class Successful : IAddOrUpdateResult
        {
            public object Entity { get; }

            public Successful(object entity)
            {
                Entity = entity;
            }
        }

        public class Failed : IAddOrUpdateResult
        {
            public string Reason { get; }

            public Failed(string reason)
            {
                Reason = reason;
            }
        }

    }
}
