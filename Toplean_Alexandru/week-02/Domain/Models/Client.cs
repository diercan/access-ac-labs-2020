using Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Client
    {
        [Required(ErrorMessage = "Name field is mandatory")]
        [StringLength(64, ErrorMessage = "Name field can have a maximum of 64 characters")]
        public String Name { get; }

        [Required(ErrorMessage = "Username field is mandatory")]
        [StringLength(64, ErrorMessage = "Username field can have a maximum of 64 characters")]
        public String Username { get; }

        [Required(ErrorMessage = "Password field is mandatory")]
        [StringLength(64, ErrorMessage = "Password field can have a maximum of 64 characters")]
        [MinLength(8, ErrorMessage = "Password must have at least 8 characters")]
        public String Password { get; } // Needs custom attribute for standard password check

        public String ClientID { get; }

        [Required(ErrorMessage = "Name field is mandatory")]
        [StringLength(50, ErrorMessage = "Name field can have a maximum of 50 characters")]
        [EmailAddress(ErrorMessage = " This is not a valid  Email Address")]
        public String Email { get; }

        public String SessionID { get; private set; }
        public Cart Cart { get; }

        [Required(ErrorMessage = "A table number must be inserted")]
        [Range(0, int.MaxValue, ErrorMessage = "The table number must be a pozitive integer")]
        public int Table { get; set; }

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

        public Client(String ClientID, String Name, String Username, String Password, String Email, String SessionID, Cart Cart)
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