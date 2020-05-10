using Domain.Domain;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class ClientAgg
    {
        public Client Client { get; }

        public String Name { get; }

        public String Username { get; }

        public String Password { get; } // Needs custom attribute for standard password check

        public String ClientID { get; }

        public String Email { get; }

        public String SessionID { get; private set; }
        public Cart Cart { get; }

        public int Table { get; set; }

        public ClientAgg(Client client)
        {
            Client = client;
            Cart = new Cart();
        }

        public void AssignClientSessionID()
        {
            String sessionID = GenerateSessionID();
            //if (AllHardcodedValues.HarcodedVals.SessionIds.Contains(sessionID))
            //AssignClientSessionID();
            //else
            SessionID = sessionID;
        }

        public String GenerateSessionID()
        {
            Random rnd = new Random();
            // Asigning a random 10 letter/digit/symbol string that will pseudo-uniquely identify a client session
            // Maximum number of assigned clients is 31,181,719,929,966,200,000
            for (int i = 0; i < 10; i++)
            {
                SessionID += ((char)rnd.Next(0x21, 0x7A));
            }
            return SessionID;
        }
    }
}