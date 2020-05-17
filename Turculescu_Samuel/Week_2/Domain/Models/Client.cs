using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Domain.Models
{
    public class Client
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }
        public string CardNumber { get; }
        public string ClientId { get; }

        public Cart Cart { get; set; }  // Each Client has a Cart with CartItems
        //public Order Order { get; set; }

        public List<Order> OrdersPlaced { get; } = new List<Order>();

        public Client(string firstName, string lastName, string email, string phone, string cardNumber, string clientId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            CardNumber = cardNumber;
            ClientId = clientId;
        }
    }
}
