using System;
using System.Collections.Generic;
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
        public (bool, RestaurantErrorCode) IsValid()
        {
            try
            {
                return HasIllegalCharacters(Name) ? (false, RestaurantErrorCode.IllegalCharacters) :
                    NameTooLong(Name) ? (false, RestaurantErrorCode.NameTooLong) :
                    NameTooShort(Name) ? (false, RestaurantErrorCode.EmptyField) :
                    (true, RestaurantErrorCode.None);
            }
            catch
            {
                return (false, RestaurantErrorCode.UnknownError);
            }
        }

        public bool NameTooLong(String name) => name.Length > 256 ? true : false;

        public bool NameTooShort(String name) => name.Length > 0 ? false : true;

        public bool HasIllegalCharacters(String name)
        {
            foreach (char c in name)
            {
                if ((int)c < 0x20 || (int)c > 0x7E)
                    return true;
            }
            return false;
        }
    }
}