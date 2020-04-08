using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateUserOp
{
    public struct CreateUserCmd
    {
        public string UserName { get; }
        public string Password { get; }
        public int Age { get; }

        public CreateUserCmd(string userName, string password, int age)
        {
            UserName = userName;
            Password = password;
            Age = age;
        }
    }
}
