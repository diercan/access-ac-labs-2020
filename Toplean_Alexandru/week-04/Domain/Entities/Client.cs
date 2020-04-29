using System;
using System.Collections.Generic;

namespace Persistence.EfCore
{
    public partial class Client
    {
        public Client()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? TableNumber { get; set; }
        public string SessionId { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
