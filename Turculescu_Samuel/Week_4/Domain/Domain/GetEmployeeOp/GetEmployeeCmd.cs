using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Domain.GetEmployeeOp
{
    public struct GetEmployeeCmd
    {
        public RestaurantAgg Restaurant { get; }
        public string EmployeeId { get; }

        public GetEmployeeCmd(RestaurantAgg restaurant, string employeeId)
        {
            Restaurant = restaurant;
            EmployeeId = employeeId;
        }
    }
}
