using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.PlaceOrderOp
{
    public struct PlaceOrderCmd
    {
        public Client Client { get; }
        public float Tip { get; }

        public PlaceOrderCmd(Client client, float tip = 0)
        {
            Client = client;
            Tip = tip;
        }

        public (bool, String) IsValid()
        {
            if (Client == null)
                return (false, "No client provided");

            if (Tip < 0)
                return (false, "Tip cannot be negative");

            return (true, "None");
        }
    }
}