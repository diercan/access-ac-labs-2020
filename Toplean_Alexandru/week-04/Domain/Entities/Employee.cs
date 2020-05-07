using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Domain.Entities;

namespace Persistence.EfCore
{
    public partial class Employee : IEntity
    {
        public Employee()
        {
        }

        public Employee(int restaurantId, String name, int age, String address, String telephone, double salary, String jobRole, String iban, String comments)
        {
            RestaurantId = restaurantId;
            Name = name;
            Age = age;
            Address = address;
            Telephone = telephone;
            Salary = salary;
            JobRole = jobRole;
            Iban = iban;
            Comments = comments;
        }

        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public double Salary { get; set; }
        public string JobRole { get; set; }
        public string Iban { get; set; }
        public string Comments { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Restaurant Restaurant { get; set; }
    }
}