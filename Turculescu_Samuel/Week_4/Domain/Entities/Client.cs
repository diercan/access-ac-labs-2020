using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EfCore
{
    public partial class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CardNumber { get; set; }
    }
}
