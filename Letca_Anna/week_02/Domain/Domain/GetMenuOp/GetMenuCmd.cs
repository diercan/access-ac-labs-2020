using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Models;
using Persistence.EfCore;

namespace Domain.Domain.GetMenuOp
{
    public class GetMenuCmd
    {
        [Required(ErrorMessage = "ValidationError_GetMenu: Null Menu.")]
        public Menus Menu { get; }
        [Required(ErrorMessage = "ValidationError_GetMenu: Null Restaurant.")]
        public RestaurantAgg RestaurantAgg { get; }
        [Required(ErrorMessage = "ValidationError_GetMenu: Null MenuItems.")]
        public List<MenuItems> MenuItems { get; }

        public GetMenuCmd(Menus menu, RestaurantAgg restaurantAgg, List<MenuItems> menuItems)
        {
            Menu = menu;
            RestaurantAgg = restaurantAgg;
            MenuItems = menuItems;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
