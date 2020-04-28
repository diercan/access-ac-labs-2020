using System;
using System.Text;

namespace Domain.Domain.GetRestaurantOp
{
    public class GetRestaurantCmd
    {
        public string Name { get; }

        public GetRestaurantCmd(string name)
        {
            Name = name;
        }
    }
}
