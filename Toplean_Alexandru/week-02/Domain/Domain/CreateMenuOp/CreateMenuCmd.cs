using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;

namespace Domain.Domain.CreateMenuOp
{
    public struct CreateMenuCmd
    {
        public Restaurant Restaurant { get; }
        public string Name { get; }
        public MenuType MenuType { get; }

        public CreateMenuCmd(Restaurant restaurant, string name, MenuType menuType)
        {
            Restaurant = restaurant;
            Name = name;
            MenuType = menuType;
        }

        // Returns a tuple. If everything is valid, the function will return true and the MenuErrorCode will be None.
        // If it is not valid, then the function will return false with the known reason.
        // Try-Catch block also added in case there is an unknown error and it will return false.
        public (bool, String) IsValid()
        {
            try
            {
                if (HasIllegalCharacters(Name))
                    return (false, "Name field contains a character that is not allowed");

                if (NameTooShort(Name))
                    return (false, "Name field is empty");

                if (Restaurant == null)
                    return (false, "No restaurant provided. Restaurant is null");

                return (true, "None");
            }
            catch (Exception exp)
            {
                return (false, exp.ToString());
            }
        }

        public bool NameTooShort(String name) => name.Length > 0 ? false : true;

        public bool HasIllegalCharacters(String name) => name.Any(c => (int)c < 0x20 || (int)c > 0x7E);
    }
}