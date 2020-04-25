using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Domain.Domain.GetRestaurantOp
{
    [AsChoice]
    public static partial class GetRestaurantResult
    {
        public interface IGetRestaurantResult{ }

        public class RestaurantFound : IGetRestaurantResult
        {
            public string Name;

            public RestaurantFound(string name)
            {
                Name = name;
                Console.WriteLine("Restaurant " + name + " found");
            }
        }
        public class RestaurantNotFound : IGetRestaurantResult
        {
            public string Reason;

            public RestaurantNotFound(string reason)
            {
                Reason = reason;
                Console.WriteLine(Reason);
            }
        }
    }
}