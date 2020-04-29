using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.Domain.CreateMenuOp
{
    public class CreateMenuCmd
    {
        [Required(ErrorMessage = "Cannot create menu for a NULL restaurant.")]
        public RestaurantAgg Restaurant { get; }

        [StringLength(100, MinimumLength=1)]
        public string Name { get; }

        public MenuType MenuType { get; }

        public CreateMenuCmd(RestaurantAgg restaurant, string name, MenuType menuType)
        {
            Restaurant = restaurant;
            Name = name;
            MenuType = menuType;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
