using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using Persistence.EfCore;

namespace Domain.Domain.CreateMenuOp
{
    public class CreateMenuCmd
    {
        //[Required(ErrorMessage = "Cannot create menu for a NULL restaurant.")]
        //public RestaurantAgg RestaurantAgg { get; }

        [StringLength(100, MinimumLength=1)]
        public string Name { get; }
        public Menus Menu { get; }
        [Required(ErrorMessage = "ValidationError_CreateMenu: Cannot create menu for a NULL restaurant.")]
        public int? RestaurantId { get; }

        //public MenuType MenuType { get; }

        public CreateMenuCmd(Menus menu, int? restaurantId)
        {
            //RestaurantAgg = restaurant;
            Menu = menu;
            RestaurantId = restaurantId;
            Name = menu.Name;

            //MenuType = menuType;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
