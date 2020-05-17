using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Domain.Models.Restaurant;

namespace Domain.Domain.CreateRestauratOp
{
    public struct CreateRestaurantCmd
    {
        public string Name { get; }

        public CreateRestaurantCmd(string name)
        {
            Name = name;
        }

        // Returns a tuple. If everything is valid, the function will return true and the RestaurantErrorCode will be None.
        // If it is not valid, then the function will return false with the known reason.
        // Try-Catch block also added in case there is an unknown error and it will return false.
        public (bool, String) IsValid()
        {
            try
            {
                if (HasIllegalCharacters(Name))
                    return (false, "The name field contains a character that is illegal");

                if (NameTooLong(Name))
                    return (false, "Name field is too long. Maximum length is 255");

                if (NameTooShort(Name))
                    return (false, "Name field is empty");

                return (true, "None");
            }
            catch (Exception exp)
            {
                return (false, exp.ToString());
            }
        }

        public bool NameTooLong(String name) => name.Length > 256 ? true : false;

        public bool NameTooShort(String name) => name.Length > 0 ? false : true;

        public bool HasIllegalCharacters(String name) => name.Any(c => (int)c < 0x20 || (int)c > 0x7E);
    }
}