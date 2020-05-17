using System;
using System.Collections.Generic;

namespace Persistence.EfCore
{
    public partial class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployerId { get; set; }

        public virtual Restaurant Employer { get; set; }
    }
}
