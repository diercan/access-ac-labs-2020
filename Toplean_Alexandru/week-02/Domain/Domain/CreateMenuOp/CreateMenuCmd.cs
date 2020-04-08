using System;
using System.Collections.Generic;
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

        public (bool, MenuErrorCode) IsValid()
        {
            try
            {
                return HasIllegalCharacters(Name) ? (false, MenuErrorCode.IllegalCharacter) :
                    NameTooShort(Name) ? (false, MenuErrorCode.EmptyField) :
                    (true, MenuErrorCode.None);
            }
            catch
            {
                return (false, MenuErrorCode.UnknownError);
            }
        }

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