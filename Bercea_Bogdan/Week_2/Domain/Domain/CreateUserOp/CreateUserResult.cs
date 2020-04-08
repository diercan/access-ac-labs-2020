using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateUserOp
{
    [AsChoice]
    public static partial class CreateUserResult
    {
        public interface ICreateUserResult
        {
         
        }

        public class UserCreated : ICreateUserResult
        {
            public User User { get; }

            public UserCreated(User user)
            {
                User = user;
            }
        }

        public class UserNotCreated : ICreateUserResult
        {
            public string ErrorMessage { get; }

            public UserNotCreated(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }

        }


    }
}
