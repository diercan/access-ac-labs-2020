using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Order
    {
        public Client Initiator { get; }

        public Order(Client initiator)
        {
            Initiator = initiator;
        }
    }
}
