using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.GetRestaurantOp
{
    public class GetRestaurantCmd
    {
        public string Name { get; }

        public GetRestaurantCmd(string name)
        {
            Name=name;
        }
    }
}
