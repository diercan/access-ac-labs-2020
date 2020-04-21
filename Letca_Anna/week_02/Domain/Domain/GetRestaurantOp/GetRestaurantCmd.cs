using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

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
