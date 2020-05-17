using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class User
    {
        public string UserName { get; }
        public string Password { get; }
        public int Age { get; }


        public User(string userName, string password, int age)
        {
            UserName = userName;
            Password = password;
            Age = age;
        }
    }
}
