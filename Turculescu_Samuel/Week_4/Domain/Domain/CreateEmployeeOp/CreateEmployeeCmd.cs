using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateEmployeeOp
{
    public struct CreateEmployeeCmd
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }
        public string Job { get; }
        public string Username { get; }
        public string Password { get; }
        public int RestaurantId { get; }

        public CreateEmployeeCmd(string firstName, string lastName, string email, string phone,string job, string username, string password, int restaurantId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Job = job;
            Username = username;
            Password = password;
            RestaurantId = restaurantId;
        }
    }
}
