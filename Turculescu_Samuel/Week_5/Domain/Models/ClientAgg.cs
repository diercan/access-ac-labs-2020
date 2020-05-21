using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ClientAgg
    {      
        public Client Client { get; set; }

        public ClientAgg(Client client)
        {
            Client = client;
        }
    }
}
