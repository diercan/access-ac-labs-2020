using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.DeleteRestaurantOp
{
    [AsChoice]
    public static partial class DeleteRestaurantResult
    {
        public interface IDeleteRestaurantResult { }

        public class RestaurantDeleted : IDeleteRestaurantResult
        {
            public bool Ok { get; }

            public RestaurantDeleted(bool ok)
            {
                Ok = ok;
            }
        }

        public class RestaurantNotDeleted : IDeleteRestaurantResult
        {
            public String Reason { get; }

            public RestaurantNotDeleted(String reason)
            {
                Reason = reason;
            }
        }
    }
}