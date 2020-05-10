using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientCmd
    {
        public string Name { get; }
        public string Email { get; }
        public string Uid { get; }
        public CreateClientCmd(string name, string email, string uid)
        {
            Name = name;
            Email = email;
            Uid = uid;
        }
    }
}
