using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.Domain.CreateMenuOp
{
    public class CreateMenuCmd
    {
        [Required]
        public Restaurant Restaurant { get; }

        [StringLength(100, MinimumLength=1)]
        public string Name { get; }

        public MenuType MenuType { get; }

        public CreateMenuCmd(Restaurant restaurant, string name, MenuType menuType)
        {
            Restaurant = restaurant;
            Name = name;
            MenuType = menuType;
        }

        public (bool, string) Validate()
        {
            var validationResults = new List<ValidationResult>();
            string validationMessage = "";
            validationResults.ForEach(x => validationMessage.Append(x.ErrorMessage));
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationMessage);
        }
    }
}
