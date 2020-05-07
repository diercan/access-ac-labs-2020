using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateClientOp
{
    public struct CreateClientCmd
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }
        public string CardNumber { get; }
        public int ClientId { get; }

        public CreateClientCmd(string firstName, string lastName, string email, string phone, string cardNumber, int clientId)
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
