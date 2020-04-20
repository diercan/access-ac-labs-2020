using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Client
    {
        public String Name { get; }
        public String Username { get; }
        public String Password { get; }
        public String ClientID { get; }
        public String Email { get; }
        public String SessionID { get; private set; }
        public Cart Cart { get; }
        public int Table { get; }

        public Client(String ClientID, String Name, String Username, String Password, String Email)
        {
            this.ClientID = ClientID;
            this.Name = Name;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
        }

        public Client(String ClientID, String Name, String Username, String Password, String Email, String SessionID, Cart Cart, int Table)
        {
            this.ClientID = ClientID;
            this.Name = Name;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.SessionID = SessionID;
            this.Cart = Cart;
            this.Table = Table;
        }

        public void AssignClientSessionID()
        {
            String sessionID = GenerateSessionID();
            if (AllHardcodedValues.HarcodedVals.SessionIds.Contains(sessionID))
                AssignClientSessionID();
            else
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