using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Domain.CreateRestauratOp
{
    public struct CreateRestaurantCmd
    {
        public Restaurant Restaurant { get; }

        public CreateRestaurantCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }

        public bool NameTooLong(String name) => name.Length > 256 ? true : false;

        public bool NameTooShort(String name) => name.Length > 0 ? false : true;

        public bool HasIllegalCharacters(String name) => name.Any(c => (int)c < 0x20 || (int)c > 0x7E);
    }
}