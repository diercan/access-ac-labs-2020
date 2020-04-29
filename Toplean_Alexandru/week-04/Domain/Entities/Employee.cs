using System;
using System.Collections.Generic;

namespace Persistence.EfCore
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public double Salary { get; set; }
        public string JobRole { get; set; }
        public string Iban { get; set; }
        public string Comments { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
