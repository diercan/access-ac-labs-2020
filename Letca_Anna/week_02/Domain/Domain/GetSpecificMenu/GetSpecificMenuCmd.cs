using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Models;
using Persistence.EfCore;
using System.Linq;
using Domain.Domain.CustomValidationAttributes;


namespace Domain.Domain.GetSpecificMenu
{
    public class GetSpecificMenuCmd
    {
        [ListNotEmpty(ErrorMessage = "ValidationError_GetMenu: Empty menu list.")]
        public List<Menus> Menus { get; }

        [Required(ErrorMessage = "ValidationError_GetSpecificMenu: Null Restaurant.")]
        public Restaurant Restaurant { get; }

        [StringLength(100, MinimumLength = 1)]
        public string MenuName { get; }

        public GetSpecificMenuCmd(Restaurant restaurant, string menuName)
        {
            Restaurant = restaurant;
            Menus = restaurant?.Menus.ToList();
            MenuName = menuName;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
