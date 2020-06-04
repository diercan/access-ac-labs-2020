using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Persistence.EfCore
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Job { get; set; }
        public string EmployeeId { get; set; }
        public string Password { get; set; }
        public int RestaurantId{ get; set; }


        public virtual Restaurant Restaurant { get; set; }
    }
}
