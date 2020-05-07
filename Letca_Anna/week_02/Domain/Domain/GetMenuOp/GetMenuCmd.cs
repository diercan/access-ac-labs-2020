using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Models;
using Persistence.EfCore;
using System.Linq;
using Domain.Domain.CustomValidationAttributes;

namespace Domain.Domain.GetMenuOp
{
    public class GetMenuCmd
    {
        [Required(ErrorMessage = "ValidationError_GetMenu: Null Menu list.")]
        [ListNotEmpty(ErrorMessage = "ValidationError_GetMenu: Empty menu list.")]
        public List<Menus> Menus { get; }

        [Required(ErrorMessage = "ValidationError_GetMenu: Null Restaurant.")]
        public Restaurant Restaurant { get; }

        public GetMenuCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
            Menus = restaurant?.Menus.ToList();
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
