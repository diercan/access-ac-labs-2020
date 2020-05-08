using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.EfCore
{
    public partial class Client : IEntity
    {
        public Client()
        {
        }

        public Client(String name, String username, String password, String email, int? tableNumber)
        {
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            TableNumber = tableNumber;
            Order = new HashSet<Order>();
            SessionId = GenerateSessionID();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public int? TableNumber { get; set; }

        public string SessionId { get; set; }

        public virtual ICollection<Order> Order { get; set; }

        public void AssignClientSessionID()
        {
            String sessionID = GenerateSessionID();

            SessionId = sessionID;
        }

        public String GenerateSessionID()
        {
            Random rnd = new Random();
            // Asigning a random 10 letter/digit/symbol string that will pseudo-uniquely identify a client session
            // Maximum number of assigned clients is 31,181,719,929,966,200,000
            for (int i = 0; i < 10; i++)
            {
                SessionId += ((char)rnd.Next(0x21, 0x7A));
            }
            return SessionId;
        }
    }
}